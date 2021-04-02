using LibUsbDotNet;
using LibUsbDotNet.Info;
using LibUsbDotNet.Main;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;

namespace Skylanders
{
    public class Program
    {
        public  UsbDevice MyUsbDevice;
        public UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(5168, 336);
        private SerialPort RFID;

        
        public static void Main(string[] args)
        {
            new Program().Start();
        }

        public void Start()
        {
            bool deviceFound;
            string devicePathName(127);
            Guid hidGuid;
            int memberIndex;
            int myProductID;
            int myVendorID;
            bool success;
            IntPtr preparsedData;
            bool myDeviceDetected;
            SafeFileHandle hidHandle;

            myDeviceDetected = false;

            // Get the device's Vendor ID and Product ID from the form's text boxes.

            myVendorID = 5168;
            myProductID = 336;

            /***
            ' API function: 'HidD_GetHidGuid

            ' Purpose: Retrieves the interface class GUID for the HID class.

            ' Accepts: 'A System.Guid object for storing the GUID.
            ***/

            HidD_GetHidGuid(hidGuid);

            // Fill an array with the device path names of all attached HIDs.

            deviceFound = MyDeviceManagement.FindDeviceFromGuid _(hidGuid, _devicePathName);

            // If there is at least one HID, attempt to read the Vendor ID and Product ID
            // of each device until there is a match or all devices have been examined.

            if (deviceFound) {
                memberIndex = 0;

                do {
                    /***
                    ' API function:
                    ' CreateFile

                    ' Purpose:
                    ' Retrieves a handle to a device.

                    ' Accepts:
                    ' A device path name returned by SetupDiGetDeviceInterfaceDetail
                    ' The type of access requested (read/write).
                    ' FILE_SHARE attributes to allow other processes to access the device while this handle is open.
                    ' A Security structure or IntPtr.Zero. 
                    ' A creation disposition value. Use OPEN_EXISTING for devices.
                    ' Flags and attributes for files. Not used for devices.
                    ' Handle to a template file. Not used.

                    ' Returns: a handle without read or write access.
                    ' This enables obtaining information about all HIDs, even system
                    ' keyboards and mice. 
                    ' Separate handles are used for reading and writing.
                    ' ***

                    ' Open the handle without read/write access to enable getting information about any HID, even system keyboards and mice.
                    */

                    hidHandle = CreateFile _(devicePathName(memberIndex), _0, _FILE_SHARE_READ Or FILE_SHARE_WRITE, _IntPtr.Zero, _OPEN_EXISTING, _0, _0);


                    if (!hidHandle.IsInvalid) {

                        // The returned handle is valid, 
                        // so find out if this is the device we're looking for.

                        // Set the Size property of DeviceAttributes to the number of bytes in the structure.

                        MyHid.DeviceAttributes.Size = Marshal.SizeOf(MyHid.DeviceAttributes);

                        /***
                        ' API function:
                        ' HidD_GetAttributes

                        ' Purpose:
                        ' Retrieves a HIDD_ATTRIBUTES structure containing the Vendor ID, 
                        ' Product ID, and Product Version Number for a device.

                        ' Accepts:
                        ' A handle returned by CreateFile.
                        ' A pointer to receive a HIDD_ATTRIBUTES structure.

                        ' Returns:
                        ' True on success, False on failure.
                        ' ***/

                        success = HidD_GetAttributes(hidHandle, MyHid.DeviceAttributes);

                        if (success) {

                            // Find out if the device matches the one we're looking for.

                            if (MyHid.DeviceAttributes.VendorID = myVendorID && MyHid.DeviceAttributes.ProductID = myProductID) {
                                //Display the information in form's list box.

                                myDeviceDetected = true;

                                //Save the DevicePathName for OnDeviceChange().

                                myDevicePathName = devicePathName(memberIndex);
                            }
                            else {

                                //It's not a match, so close the handle.

                                myDeviceDetected = false;

                                hidHandle.Close();

                            }
                        }
                        else {
                            // There was a problem in retrieving the information.

                            myDeviceDetected = false;
                            hidHandle.Close();
                        }

                    }

                    //Keep looking until we find the device or there are no devices left to examine.

                    memberIndex = memberIndex + 1;

                    while (myDeviceDetected || memberIndex == devicePathName.Length) ;

                }


        if (myDeviceDetected) {

                    // The device was detected.
                    // Register to receive notifications if the device is removed or attached.

                    MyDeviceManagement.RegisterForDeviceNotifications(myDevicePathName, frmMain.Handle, hidGuid, deviceNotificationHandle);


                    // Learn the capabilities of the device.

                    HidD_GetPreparsedData(hidHandle, preparsedData);
                    HidP_GetCaps(preparsedData, MyHid.Capabilities);
                    if (preparsedData != IntPtr.Zero) {
                        HidD_FreePreparsedData(preparsedData);
                    }


                    // Get the Input report buffer size.
                    // GetInputReportBufferSize()
                    // Close the handle and reopen it with read/write access.

                    hidHandle.Close();

                    hidHandle = CreateFile(myDevicePathName, _GENERIC_READ Or GENERIC_WRITE, _FILE_SHARE_READ Or FILE_SHARE_WRITE, _IntPtr.Zero, _OPEN_EXISTING, _0, _0);

                    deviceStream = new FileStream(hidHandle, FileAccess.Read Or FileAccess.Write, reportSize, False);


                    // Flush any waiting reports in the input buffer. (optional)

                    HidD_FlushQueue(hidHandle);
                    frmMain.unlockPortalControls();
                    frmMain.SaldeStatus.Text = "Portal Connected!";
                    Portal.blnPortal = True;
                }
                else {
                    // The device wasn't detected.
                    frmMain.lockPortalControls();
                    frmMain.SaldeStatus.Text = "Portal Not Found!";
                    Portal.blnPortal = false;
                }

                return hidHandle;
        }
    }
}
