using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace Skylanders
{
    public class Hid
    {
		public const short HidP_Input = 0;
		public const short HidP_Output = 1;
		public const short HidP_Feature = 2;
		public HIDP_CAPS Capabilities;
		public HIDD_ATTRIBUTES DeviceAttributes;

		public struct HIDD_ATTRIBUTES
		{
			public int Size;
			public ushort VendorID;
			public ushort ProductID;
			public ushort VersionNumber;
		}

		public struct HIDP_CAPS 
		{
			public short Usage;
			public short UsagePage;
			public short InputReportByteLength;
			public short OutputReportByteLength;
			public short FeatureReportByteLength;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
			public short[] NumberLinkCollectionNodes;
			public short NumberInputButtonCaps;
			public short NumberInputValueCaps;
			public short NumberInputDataIndices;
			public short NumberOutputButtonCaps;
			public short NumberOutputValueCaps;
			public short NumberOutputDataIndices;
			public short NumberFeatureButtonCaps;
			public short NumberFeatureValueCaps;
			public short NumberFeatureDataIndices;
		}

		public struct HidP_Value_Caps
		{
			public short UsagePage;
			public byte ReportID;
			public int IsAlias;
			public short BitField;
			public short LinkCollection;
			public short LinkUsage;
			public short LinkUsagePage;
			public int IsRange;
			public int IsStringRange;
			public int IsDesignatorRange;
			public int IsAbsolute;
			public int HasNull;
			public byte Reserved;
			public short BitSize;
			public short ReportCount;
			public short Reserved2;
			public short Reserved3;
			public short Reserved4;
			public short Reserved5;
			public short Reserved6;
			public int LogicalMin;
			public int LogicalMax;
			public int PhysicalMin;
			public int PhysicalMax;
			public short UsageMin;
			public short UsageMax;
			public short StringMin;
			public short StringMax;
			public short DesignatorMin;
			public short DesignatorMax;
			public short DataIndexMin;
			public short DataIndexMax;
		}

		[DllImport("hid.dll" , SetLastError = true)]
        public static extern bool HidD_FlushQueue(SafeFileHandle HidDeviceObject);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool HidD_FreePreparsedData(IntPtr PreparsedData);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool HidD_GetAttributes(SafeFileHandle HidDeviceObject, HIDD_ATTRIBUTES Attributes);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool HidD_GetFeature(SafeFileHandle HidDeviceObject, Byte lpReportBuffer, int ReportBufferLength);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool HidD_GetInputReport(SafeFileHandle HidDeviceObject, Byte lpReportBuffer, int ReportBufferLength);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern void HidD_GetHidGuid(out Guid HidGuid);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool HidD_GetNumInputBuffers(SafeFileHandle HidDeviceObject, int NumberBuffers);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool HidD_GetPreparsedData(SafeFileHandle HidDeviceObject, IntPtr PreparsedData);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool HidD_SetFeature(SafeFileHandle HidDeviceObject, byte lpReportBuffer, int ReportBufferLength);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool HidD_SetNumInputBuffers(SafeFileHandle HidDeviceObject, int NumberBuffers);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool HidD_SetOutputReport(SafeFileHandle HidDeviceObject, byte lpReportBuffer, int ReportBufferLength);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool HidD_GetCaps(IntPtr PreparsedData, HIDP_CAPS Capabilities);

		[DllImport("hid.dll", SetLastError = true)]
		public static extern bool HidD_GetValueCaps(int ReportType, byte ValueCaps, int ValueCapsLength, IntPtr PreparsedData);
	}
}
