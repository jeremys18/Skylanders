using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace SkylandersManagerUI
{
    public class Portal
    {
        static byte[] outRepoBytes = new byte[32];
        static byte[] inRepoBytes = new byte[32];
        public static bool blnAccess = false;
        public static bool BlnPortalUsed = false;
        public static SafeHandle portalHandle;
        public static bool blnPortal = false;
        private static byte space = Convert.ToByte(' '); // Ascii 20
        private static byte explanationMark = Convert.ToByte('!'); // Ascii 21
        private static byte questionMark = Convert.ToByte('?'); // Ascii 3F
        private static byte A = Convert.ToByte('A'); // Ascii 41
        private static byte C = Convert.ToByte('C'); // Ascii 43
        private static byte Q = Convert.ToByte('Q'); // Ascii 51
        private static byte R = Convert.ToByte('R'); // Ascii 52
        private static byte S = Convert.ToByte('S'); // Ascii 53
        private static byte W = Convert.ToByte('W'); // Ascii 57
        

        // Connect to the Portal, using HID
        static void ReadPortal() {
            // reads skylander data from the portal
            int timeout;
            int readBlock;
            blnAccess = false;

            // Reset portal
            outRepoBytes[1] = R; 
            outputReport(portalHandle, outRepoBytes);
            Thread.Sleep(50);

            outRepoBytes[1] = A;
            outRepoBytes[2] = 1;
            outputReport(portalHandle, outRepoBytes);
            Thread.Sleep(500);

            // set to "read first skylander" mode
            outRepoBytes[1] = Q;
            outRepoBytes[2] = space; //First Figure
            readBlock = 0;
            do {
                // send report and flush hid queue
                outRepoBytes[3] = readBlock;
                outputReport(portalHandle, outRepoBytes);
                flushHid(portalHandle);
                timeout = 0;
                do {
                    // read the reply from the portal, the portal replies between 1 and 2 reports later
                    inputReport(portalHandle, inRepoBytes);
                    timeout = timeout + 1;
                } while (inRepoBytes[1] != S || timeout == 4);  //53 is S

                if (timeout != 4) {
                    // if we didn't time out we copy the the bytes into the array
                    Array.Copy(inRepoBytes, 4, WholeFile, readBlock * 16, 16);
                    readBlock = readBlock + 1;
                }
                // MessageBox.Show(AES.ByteArrayToString(inRepoBytes).ToUpper)
            }
            while (readBlock <= space); // Last Block
            frmMain.Save_Enc_ToolStripMenuItem.Enabled = true;
            frmMain.Save_Dec_ToolStripMenuItem.Enabled = true;
            MiFare.Detection();
            if (blnAccess) {
                MessageBox.Show("Error.  Invalid Control Blocks found.")
                return;
            }

            BlnPortalUsed = true;
        }

        static void Portal_Write()
        {
            // Magic.
            // write data to skylander in portal
            int writeBlock;
            // reset portal
            outRepoBytes[1] = R; 
            outputReport(portalHandle, outRepoBytes);
            Thread.Sleep(50);

            outRepoBytes[1] = A;
            outRepoBytes[2] = 1;
            outputReport(portalHandle, outRepoBytes);
            Thread.Sleep(500);

            // set to "write first skylander" mode
            outRepoBytes[1] = W; 
            outRepoBytes[2] = space; // First Figure
            writeBlock = 5;
            do {
                outRepoBytes[3] = writeBlock;
                // we get the bytes from the data array and put out the report, we need to wait a bit before sending another write report too
                Array.Copy(WholeFile, writeBlock * 16, outRepoBytes, 4, 16);
                outputReport(portalHandle, outRepoBytes);
                Thread.Sleep(100);
                writeBlock = writeBlock + 1;
            }
            while (writeBlock <= space); // Last Block
            frmMain.SaldeStatus.Text = "Save Completed to portal";
        }

        static void Portal_Duo_Read()
        {
            // Same as read from portal, but reads the second position skylander (usually the Top half of a Swap Force)
            int timeout;
            int readBlock;

            outRepoBytes[1] = R; // R
            outputReport(portalHandle, outRepoBytes);
            Thread.Sleep(50);

            outRepoBytes[1] = A; // A
            outRepoBytes[2] = 1;
            outputReport(portalHandle, outRepoBytes);
            Thread.Sleep(500);

            outRepoBytes[1] = Q; // Q
            outRepoBytes[2] = explanationMark; // Second Figure
            readBlock = 0;
            do
            {
                outRepoBytes[3] = readBlock;
                outputReport(portalHandle, outRepoBytes);
                flushHid(portalHandle);
                timeout = 0;
                do
                {
                    inputReport(portalHandle, inRepoBytes);
                    timeout = timeout + 1;
                } while (inRepoBytes[1] != S || timeout == 4);

                if (timeout != 4)
                {
                    Array.Copy(inRepoBytes, 4, WholeFile, readBlock * 16, 16);
                    readBlock = readBlock + 1;
                }
            } while (readBlock <= space); // Final Block
                                         
            // Parse_Figure()
            BlnPortalUsed = true;
        }

        static void Portal_Duo_Write()
        {
            // Magic.
            // write data to skylander in portal
            int writeBlock;
            // reset portal
            outRepoBytes[1] = R; 
            outputReport(portalHandle, outRepoBytes);
            Thread.Sleep(50);

            outRepoBytes[1] = A; 
            outRepoBytes[2] = 1;
            outputReport(portalHandle, outRepoBytes);
            Thread.Sleep(500);

            // set to "write first skylander" mode
            outRepoBytes[1] = W;
            outRepoBytes[2] = explanationMark; // Second Figure
            writeBlock = 5;

            // I need to look into this further
            // I need to and Write ALL bytes/Blocks
            do
            {
                outRepoBytes[3] = writeBlock;
                // we get the bytes from the data array and put out the report, we need to wait a bit before sending another write report too


                Array.Copy(WholeFile, writeBlock * 16, outRepoBytes, 4, 16);
                outputReport(portalHandle, outRepoBytes);
                Thread.Sleep(100);
                writeBlock = writeBlock + 1;
            } while (writeBlock <= space); //Last Block 63

            frmMain.SaldeStatus.Text = "Save Completed to portal";
        }

        static void Portal_Rainbow(byte Red, byte Green, byte Blue)
        {
            blnAccess = false;

            //Reset portal
            outRepoBytes[1] = C;  
            outRepoBytes[2] = Red;   
            outRepoBytes[3] = Green; 
            outRepoBytes[4] = Blue; 

            outputReport(portalHandle, outRepoBytes);
            Thread.Sleep(50);
        }
    }
}
