using System;
using System.IO;

namespace SkylandersManagerUI
{
    public class FigureIO
    {
        // Shared Variables
        // We need to make BR and FS public shared so other Classes can access it
        public static FileStream fs;
        public static BinaryReader br;
        public static byte[] WholeFile = new byte[1024];
        public static bool blnEncrypted = false;
        public static string File;

        // These three are the Unique trio.  They are not like other figures
        public static bool blnTrap = false;
        public static bool BlnVehicle = false;
        public static bool blnCrystal = false;

        // Call all the Functions for the Figure, when relevant.
        // TODO:
        // Improve Figure Identification and Handling.

        public static void Load_File()
        {
            var result = frmMain.ofdSky.ShowDialog();
            if (result = DialogResult.OK)
            {
                //  Test result.
                File = frmMain.ofdSky.FileName;
            }
            else
            {
                // Do Nothing
                return;
            }

            try
            {
                fs = new FileStream(File, FileMode.Open);
            }
            catch (Exception ex)
            {
                // frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & "Unable to Open " & File
                // frmLog.Show()
                return;
            }

            if (fs.Length = 1024)
            {
            }
            else if (fs.Length = 2048)
            {
                // SWAP
                // MessageBox.Show("Sorry, this program does not handle a Maxlander Swap Force Dump.")
                frmMain.SaldeStatus.Text = "Sorry, this program does not handle a Maxlander Swap Force Dump.";
                // frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & "Sorry, this program does not handle a Maxlander Swap Force Dump."
                // frmLog.Show()
                return;
            }
            else
            {
                // frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & "The Figure must be 1 Kilobyte."
                // frmLog.Show()
                frmMain.SaldeStatus.Text = "The Figure must be 1 Kilobyte.";
                fs.Close();
                return;
            }

            // Reset the Form, Just in Case
            frmMain.cmbGame.SelectedIndex = 0;
            frmMain.cmbHat.SelectedIndex = 0;
            br = new BinaryReader(fs);
            // Put the whole file into an array.
            WholeFile = br.ReadBytes(1024);
            br.Close(); // close the Binary Reader
            fs.Close(); //  close the FileStream

            Parse_Figure();
        }

        public static void Parse_Figure()
        {
            // We set the Decrypted Flag here
            blnEncrypted = false;
            // We set the Unique Trio Booleans to False.
            BlnVehicle = false;
            blnTrap = false;
            blnCrystal = false;
            // We Reset WebCode here and early.
            frmMain.lblWebCode.Text = "";
            // We can get the Figure// s ID and Variant ID without Needing Encryption/Decryption
            // Get Figure ID and Alter Ego/Variant
            Figures.GetFigureID_AlterEgo_Variant();

            // Because Traps, Vehciles and Crystals are writing bytes to where the Nickname would normally show up, we Do NOT attempt to Decrypt here.
            // Though, Crystals may write here?
            if (!blnTrap && !blnCrystal && !BlnVehicle)
            {
                blnEncrypted = Enc_Fig();
            }
            else if (blnTrap)
            {
                blnEncrypted = Enc_Trap();
            }
            else if (BlnVehicle)
            {
                blnEncrypted = Enc_Veh();
            }
            else if (blnCrystal)
            {
                // Not Implimented Yet.
            }
            if (blnEncrypted)
            {
                Decrypt();
            }

            // Calculate the Checksums
            // Does NOT handle Traps or Crystals, yet.
            CRC16CCITT.Checksums();
            // Determine if we are going to use Area 0 or Area 1
            Figures.Area0orArea1();
            frmArea.Area0_1();

            // We break here if Vehicle, Crystal, Item or Trap
            if (BlnVehicle)
            {
                Application.DoEvents();
                var frmVehicles = new frmVehicles();
                frmVehicles.Show();
                frmMain.Hide();
                return;
            }
            else if (blnTrap)
            {
                Application.DoEvents();
                var frmTraps = new frmTraps();
                frmTraps.Show();
                frmMain.Hide();
                return;
            }
            else if (blnCrystal)
            {
#if DEBUG
                Application.DoEvents();
                var FrmCrystals = new frmCrystals();
                FrmCrystals.Show();
                frmMain.Hide();
                return;
#else
                frmMain.SaldeStatus.Text = "Crystals are not supported, yet.";
                return;
#endif

            }

            // Get the Current Skill Path.
            Skills.GetSkillPath();

            // Get the Current Hero Points value for Areas A and B.  Show the Larger Value.
            Hero.GetHero();

            // Get the Current Gold values for Areas A and B.  Show the Larger Value.
            Gold.GetGold();

            // Get EXP
            Exp.GetEXP();

            // Get the Current Heroic Challenges value for Areas A and B.  Show the Larger Value.
            Challenges.GetChallenges();

            // Show us what Figure we got.
            // Show us the Figures ID and Variant ID
            // Figures.ShowID()

            // Mostly complete Detection
            Figures.FigureItOut();

            // Select the Hat
            Hats.ReadHats();
            // btnSaveAs.Enabled = True
            // btnWrite.Enabled = True

            Web_Code.Load();
            // btnSaveAs.Enabled = True
            // btnWrite.Enabled = True

            System_ID.ReadSystem_ID();
        }

        // Write_Data write// s Data to the Figures.
        // Note that Traps, Vehicles and Crystals do NOT use this because they have their own Editor that is used.
        public static void Write_Data()
        {
            if (!BlnVehicle && !blnTrap && !blnCrystal)
            {
                // Set Data that changed.
                Challenges.WriteChallenges();
                Exp.WriteEXP();
                Gold.WriteGold();
                Hero.WriteHero();
                Nickname.SetNickname();
                Hats.WriteHats();
                if (frmMain.numLevel.Value >= 10)
                {
                    Skills.WriteSkillPath();
                }
            }

            if (blnTrap)
            {
                // Special Byte Data Writes
                var ZeroTrap = 0;
                // Add 13 to reach End of Block
                // 194 = 0C2
                // 258 = 102
                // 322 = 142
                // 386 = 182
                // 450 = 1C2
                // 515 = 202

                // Then we do Area 2
                // +1C0
                // 642 = 282
                // 706 = 2C2
                // 770 = 302
                // 834 = 342
                // 898 = 382
                // 962 = 3C2

                var trap_Name = new int[] { 194, 258, 322, 386, 450, 515, 642, 706, 770, 834, 898, 962 };
                var trapCounter = 0;

                do
                {
                    WholeFile[trap_Name[trapCounter] + ZeroTrap] = 0x0;
                    if (ZeroTrap = 13)
                    {
                        ZeroTrap = 0;
                        trapCounter += 1;
                    }
                    else
                    {
                        ZeroTrap += 1;
                    }
                } while (trapCounter != 12);
            }
            else if (BlnVehicle)
            {
                // Special Byte Data Writes
                var ZeroVehicle = 0;
                // 192 = 0C0
                // +1C0
                // 640 = 280
                do
                {
                    WholeFile[192 + ZeroVehicle] = 0x0;
                    ZeroVehicle += 1;
                } while (ZeroVehicle != 14);

                ZeroVehicle = 0;
                do
                {
                    WholeFile[640 + ZeroVehicle] = 0x0;
                    ZeroVehicle += 1;
                } while (ZeroVehicle != 14);
            }
            else if (blnCrystal)
            {
                // Special Byte Data Writes
                // Not Implimented, Yet.
            }
            // All Figures need these Functions still.
            // Write the System ID
            System_ID.WriteSystem();
            // Fix Read/Write Blocks
            Figures.Fixing_Bytes();
            // In theory, this will fix any issues with the Edited Dumps.
            Figures.SetArea0AndArea1();
            // Fix the Checksums.
            CRC16CCITT.WriteCheckSums();
        }

        public static void Write_Decrypted_Figure()
        {
            // Save As
            var dialog = new SaveFileDialog
            {
                Filter = "Dump File (*.bin)|*.bin|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                Title = "Save Decrypted Dump",
                FileName = frmMain.lstCharacters.SelectedItem
            };
            if (dialog.ShowDialog == DialogResult.OK)
            {
                var newFile = dialog.FileName;

                if (frmMain.chkSerial.Checked)
                {
                    CRC16CCITT.GenerateNewSerial();
                }
                Figures.EditCharacterIDVariant();
                Write_Data();
                // Now we write the file.
                fs = new FileStream(NewFile, FileMode.OpenOrCreate);
                fs.Write(WholeFile, 0, WholeFile.Length);
                fs.Flush();
                fs.Close();
            }
        }

        public static void Write_Encrypted_Figure()
        {
            // Save As
            var dialog = new SaveFileDialog
            {
                Filter = "Dump File (*.bin)|*.bin|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                Title = "Save Encrypted Dump",
                FileName = frmMain.lstCharacters.SelectedItem
            };
            if (dialog.ShowDialog = DialogResult.OK)
            {
                var newFile = dialog.FileName;

                if(frmMain.chkSerial.Checked)
                {
                    CRC16CCITT.GenerateNewSerial();
                }
                Figures.EditCharacterIDVariant();
                Write_Data();
                // Since we are Writing an Encrypted Figure, I need to Re-Encrypt it.
                Encrypt();
                // Now we write the file.
                fs = new FileStream(NewFile, FileMode.OpenOrCreate);
                fs.Write(WholeFile, 0, WholeFile.Length);
                fs.Flush();
                fs.Close();
                // We Decrypt after we are done.
                Decrypt();
            }
        }

        public static void Raw_Write()
        {
            // Save As
            var dialog = new SaveFileDialog
            {
                Filter = "Dump File (*.bin)|*.bin|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                Title = "Save Decrypted Dump",
                FileName = frmMain.lstCharacters.SelectedItem
            };

            if (dialog.ShowDialog = DialogResult.OK)
            {
                var NewFile = dialog.FileName;
                fs = New FileStream(NewFile, FileMode.OpenOrCreate);
                fs.Write(WholeFile, 0, WholeFile.Length);
                fs.Flush();
                fs.Close();
            }
        }
        // We Put Decryption and Encrytion in this Module due to being Relevant to Figure I/O

        public static void Decrypt()
        {
            // Get Header Bytes
            AES.Header();
            #region " Blocks "
            // The Following blocks (Offsets) are NOT encrypted
            // All Offsets are in Hex and counted as such.
            // 0x000 Through 0x70
            // 0x0B0
            // 0x0F0
            // 0x130
            // 0x170
            // 0x1B0
            // 0x1F0
            // 0x230
            // 0x270
            // 0x2B0
            // 0x2F0
            // 0x330
            // 0x370
            // 0x3B0
            // 0X3F0

            // Offsets that are Encrypted: (All 16 Bytes in Length)
            // 0x080 // 128 // Need 08
            // 0x090 // 144 // Need 09
            // 0x0A0 // Nickname A // 160 // Need 0A Not A0  // 150 Diff

            // 0x0C0 // 192
            // 0x0D0 // 208
            // 0x0E0 // 224

            // 0x100 // 256
            // 0x110 // 272
            // 0x120 // 288

            // 0x140 // 320
            // 0x150 // 336
            // 0x160 // 352

            // 0x180 // 384
            // 0x190 // 400
            // 0x1A0 // 416

            // 0x1C0 // 448
            // 0x1D0 // 464
            // 0x1E0 // 480

            // 0x200 // 512
            // 0x210 // 528
            // 0x220 // 544

            // 0x240 // 576
            // 0x250 // 592
            // 0x260 // Nickname B  // 608

            // 0x280 // 640
            // 0x290 // 656
            // 0x2A0 // 672

            // 0x2C0 // 704
            // 0x2D0 // 720
            // 0x2E0 // 736

            // 0x300 // 768
            // 0x310 // 784
            // 0x320 // 800

            // 0x340 // 832
            // 0x350 // 848
            // 0x360 // 864

            // 0x380 // 896
            // 0x390 // 912
            // 0x3A0 // 928

            // 0x3C0 // 960
            // 0x3D0 // 976
            // 0x3E0 // 992
            #endregion

            var Offsets = new int[] { 128, 144, 160, 192, 208, 224, 256, 272, 288, 320, 336, 352, 384, 400, 416, 448, 464, 480, 512, 528, 544, 576, 592, 608, 640, 656, 672, 704, 720, 736, 768, 784, 800, 832, 848, 864, 896, 912, 928, 960, 976, 992 };
            var AreaKey = new byte[] { 0x8, 0x9, 0xA, 0xC, 0xD, 0xE, 0x10, 0x11, 0x12, 0x14, 0x15, 0x16, 0x18, 0x19, 0x1A, 0x1C, 0x1D, 0x1E, 0x20, 0x21, 0x22, 0x24, 0x25, 0x26, 0x28, 0x29, 0x2A, 0x2C, 0x2D, 0x2E, 0x30, 0x31, 0x32, 0x34, 0x35, 0x36, 0x38, 0x39, 0x3A, 0x3C, 0x3D, 0x3E };
            // MessageBox.Show(AreaKey.Length)
            var AreaBytes = new byte[16];

            // MessageBox.Show(Offsets.Length) // 42

            var OffsetCounter = 0;
            var Counter = 0;  // Necessary to add one to the Byte array Offset
            var HeadByteCounter = 0; // = 160 // Use Integer, FTW!

            do
            {
                HeadByteCounter = Offsets[OffsetCounter];
                // MessageBox.Show(HeadByteCounter)
                // Get Bytes from the Encrypted Offset
                do
                {
                    // Fill areaBytes, with WholeFile.
                    // AreaBytes(0-15) = WholeFile(HeadByteCounter)
                    AreaBytes[Counter] = WholeFile[HeadByteCounter];
                    HeadByteCounter += 1;
                    Counter += 1;
                } while (Counter != 16);

                // MessageBox.Show("ValueBytes " & BitConverter.ToString(AreaBytes))
                // MessageBox.Show("AreaKey " & AreaKey(OffsetCounter))
                AES.GetKey(AreaKey(OffsetCounter));

                var Output = AES.AESD(AreaBytes, AES.FullKey);

                // Fillback Loop
                Counter = 0;
                HeadByteCounter = Offsets(OffsetCounter); // Use Integer, FTW!
                                                          // Data back in
                do
                {
                    WholeFile[HeadByteCounter] = Output[Counter];
                    HeadByteCounter += 1;
                    Counter += 1;
                } while (OffsetCounter != 16);

                // MessageBox.Show("Output " & BitConverter.ToString(Output))
                Counter = 0;
                OffsetCounter += 1;
            } while (OffsetCounter != 42);

            // MessageBox.Show("Nickname")
            // We get Nickname here, to see if it// s still Encrypted.
            Nickname.GetNickname();
        }
        public static void Encrypt()
        {
            // Get Header Bytes
            AES.Header();
            #region " Blocks "
            // The Following blocks (Offsets) are NOT encrypted
            // All Offsets are in Hex and counted as such.
            // 0x000 Through 0x70
            // 0x0B0
            // 0x0F0
            // 0x130
            // 0x170
            // 0x1B0
            // 0x1F0
            // 0x230
            // 0x270
            // 0x2B0
            // 0x2F0
            // 0x330
            // 0x370
            // 0x3B0
            // 0X3F0

            // Offsets that are Encrypted: (All 16 Bytes in Length)
            // 0x080 // 128 // Need 08
            // 0x090 // 144 // Need 09
            // 0x0A0 // Nickname A // 160 // Need 0A Not A0  // 150 Diff

            // 0x0C0 // 192
            // 0x0D0 // 208
            // 0x0E0 // 224

            // 0x100 // 256
            // 0x110 // 272
            // 0x120 // 288

            // 0x140 // 320
            // 0x150 // 336
            // 0x160 // 352

            // 0x180 // 384
            // 0x190 // 400
            // 0x1A0 // 416

            // 0x1C0 // 448
            // 0x1D0 // 464
            // 0x1E0 // 480

            // 0x200 // 512
            // 0x210 // 528
            // 0x220 // 544

            // 0x240 // 576
            // 0x250 // 592
            // 0x260 // Nickname B  // 608

            // 0x280 // 640
            // 0x290 // 656
            // 0x2A0 // 672

            // 0x2C0 // 704
            // 0x2D0 // 720
            // 0x2E0 // 736

            // 0x300 // 768
            // 0x310 // 784
            // 0x320 // 800

            // 0x340 // 832
            // 0x350 // 848
            // 0x360 // 864

            // 0x380 // 896
            // 0x390 // 912
            // 0x3A0 // 928

            // 0x3C0 // 960
            // 0x3D0 // 976
            // 0x3E0 // 992
            #endregion

            var Offsets = new int[] { 128, 144, 160, 192, 208, 224, 256, 272, 288, 320, 336, 352, 384, 400, 416, 448, 464, 480, 512, 528, 544, 576, 592, 608, 640, 656, 672, 704, 720, 736, 768, 784, 800, 832, 848, 864, 896, 912, 928, 960, 976, 992 };
            var AreaKey = new byte[] { 0x8, 0x9, 0xA, 0xC, 0xD, 0xE, 0x10, 0x11, 0x12, 0x14, 0x15, 0x16, 0x18, 0x19, 0x1A, 0x1C, 0x1D, 0x1E, 0x20, 0x21, 0x22, 0x24, 0x25, 0x26, 0x28, 0x29, 0x2A, 0x2C, 0x2D, 0x2E, 0x30, 0x31, 0x32, 0x34, 0x35, 0x36, 0x38, 0x39, 0x3A, 0x3C, 0x3D, 0x3E };
            // MessageBox.Show(AreaKey.Length)
            var AreaBytes = new byte[16];

            // MessageBox.Show(Offsets.Length) // 42
            var OffsetCounter = 0;

            var Counter = 0;  // Necessary to add one to the Byte array Offset
            var HeadByteCounter = 0; // = 160 // Use Integer, FTW!
            do
            {
                HeadByteCounter = Offsets[OffsetCounter];
                // MessageBox.Show(HeadByteCounter)
                // Get Bytes from the Encrypted Offset
                do
                {
                    // Fill areaBytes, with WholeFile.
                    // AreaBytes(0-15) = WholeFile(HeadByteCounter)
                    AreaBytes[Counter] = WholeFile[HeadByteCounter];
                    HeadByteCounter += 1;
                    Counter += 1;
                } while (OffsetCounter != 16);


                // MessageBox.Show("ValueBytes " & BitConverter.ToString(AreaBytes))
                // MessageBox.Show("AreaKey " & AreaKey(OffsetCounter))
                AES.GetKey(AreaKey[OffsetCounter]);
                var Output = AES.AESE(AreaBytes, AES.FullKey);

                // Fillback Loop
                Counter = 0;
                HeadByteCounter = Offsets[OffsetCounter]; // Use Integer, FTW!
                                                          // Data back in
                do
                {
                    WholeFile[HeadByteCounter] = Output[Counter];
                    HeadByteCounter += 1;
                    Counter += 1;
                } while (OffsetCounter != 16);

                // MessageBox.Show("Output " & BitConverter.ToString(Output))
                Counter = 0;
                OffsetCounter += 1;
            } while (OffsetCounter != 42);
        }

        public static bool Enc_Fig()
        {
            // We do a special Check for Bytes Being Set in the wrong places.
            // Check 0x150 through 0x15F
            // Check 0x310 through 0x31F
            // 336 = 150
            // 784 = 310
            var ZeroFigure = 0;
            do
            {
                if (WholeFile[336 + ZeroFigure] != 0x0)
                {
                    return true;
                }
                else
                {
                    ZeroFigure += 1;
                }
            } while (ZeroFigure != 16);

            ZeroFigure = 0;
            do
            {
                if (WholeFile[784 + ZeroFigure] != 0x0)
                {
                    return true;
                }
                else
                {
                    ZeroFigure += 1;
                }
            } while (ZeroFigure != 16);
            return false;
        }
        public static bool Enc_Trap()
        {
            // We do a Clean Check for If the Trap is Encrypted, by checking places we KNOW should be blank.
            // Special Byte Data Writes
            var ZeroTrap = 0;
            // Add 13 to reach End of Block
            // 194 = 0C2
            // 258 = 102
            // 322 = 142
            // 386 = 182
            // 450 = 1C2
            // 515 = 202

            // Then we do Area 2
            // +1C0
            // 642 = 282
            // 706 = 2C2
            // 770 = 302
            // 834 = 342
            // 898 = 382
            // 962 = 3C2

            var Trap_Name = new int[] { 194, 258, 322, 386, 450, 515, 642, 706, 770, 834, 898, 962 };
            var TrapCounter = 0;
            do
            {
                if (WholeFile[Trap_Name[TrapCounter] + ZeroTrap] != 0x0)
                {
                    return true;
                }
                else
                {
                    if (ZeroTrap == 13)
                    {
                        ZeroTrap = 0;
                        TrapCounter += 1;
                    }
                    else
                    {
                        ZeroTrap += 1;
                    }
                }
            } while (TrapCounter != 12);

            return false;
        }
        public static bool Enc_Veh()
        {
            // We do a Clean Check for If the Vehicle is Encrypted, by checking places we KNOW should be blank.
            // Special Byte Data Checks
            var ZeroVehicle = 0;
            // 192 = 0C0
            // +1C0
            // 640 = 280
            do
            {
                // WholeFile(192 + ZeroVehicle) = 0x0
                if (WholeFile[192 + ZeroVehicle] != 0x0)
                {
                    return true;
                }
                else
                {
                    ZeroVehicle += 1;
                }
            } while (ZeroVehicle != 14);

            ZeroVehicle = 0;
            do
            {
                // WholeFile(640 + ZeroVehicle) = 0x0
                if (WholeFile[640 + ZeroVehicle] != 0x0)
                {
                    blnEncrypted = true;
                }
                else
                {
                    ZeroVehicle += 1;
                }
            } while (ZeroVehicle != 14);

            // Default Action
            return false;
        }
    }
}
