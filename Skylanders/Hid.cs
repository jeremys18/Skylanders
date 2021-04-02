using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace Skylanders
{
    public static class Hid
    {
		[DllImport("hid.dll" , SetLastError = true)]
        public static extern bool FlushQueue(SafeFileHandle HidDeviceObject);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool FreePreparsedData(IntPtr PreparsedData);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool GetAttributes(SafeFileHandle HidDeviceObject, HIDD_ATTRIBUTES Attributes);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool GetFeature(SafeFileHandle HidDeviceObject, Byte lpReportBuffer, Int32 ReportBufferLength);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool GetInputReport(SafeFileHandle HidDeviceObject, Byte lpReportBuffer, Int32 ReportBufferLength);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern void HidD_GetHidGuid(out Guid HidGuid);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool GetNumInputBuffers(SafeFileHandle HidDeviceObject, Int32 NumberBuffers);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool GetPreparsedData(SafeFileHandle HidDeviceObject, IntPtr PreparsedData);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool SetFeature(SafeFileHandle HidDeviceObject, byte lpReportBuffer, Int32 ReportBufferLength);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool SetNumInputBuffers(SafeFileHandle HidDeviceObject, Int32 NumberBuffers);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool SetOutputReport(SafeFileHandle HidDeviceObject, byte lpReportBuffer, Int32 ReportBufferLength);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool GetCaps(IntPtr PreparsedData, HIDP_CAPS Capabilities);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool GetValueCaps(Int32 ReportType, byte ValueCaps, Int32 ValueCapsLength, IntPtr PreparsedData);
	}
}
