using System;
using System.Runtime.InteropServices;

namespace SkylandersManagerUI
{
    internal partial class DeviceManagementDeclarations
	{
        ///<remarks>
		/// API declarations relating to device management (SetupDixxx and 
		/// RegisterDeviceNotification functions).
		/// constants are from dbt.h and setupapi.h.
		///</remarks>
		internal const int DBT_DEVICEARRIVAL = 0x8000;
		internal const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
		internal const int DBT_DEVTYP_DEVICEINTERFACE = 5;
		internal const int DBT_DEVTYP_HANDLE = 6;
		internal const int DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = 4;
		internal const int DEVICE_NOTIFY_SERVICE_HANDLE = 1;
		internal const int DEVICE_NOTIFY_WINDOW_HANDLE = 0;
		internal const int WM_DEVICECHANGE = 0x219;
		internal const int DIGCF_PRESENT = 2;
		internal const int DIGCF_DEVICEINTERFACE = 0x10;

		// Two declarations for the DEV_BROADCAST_DEVICEINTERFACE structure.
		// Use this one in the call to RegisterDeviceNotification() and
		// in checking dbch_devicetype in a DEV_BROADCAST_HDR structure:
		[StructLayout(LayoutKind.Sequential)]
		internal class DEV_BROADCAST_DEVICEINTERFACE
		{
			internal int dbcc_size;
			internal int dbcc_devicetype;
			internal int dbcc_reserved;
			internal Guid dbcc_classguid;
			internal short dbcc_name;
		}

		// Use this to read the dbcc_name string and classguid:
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		internal class DEV_BROADCAST_DEVICEINTERFACE_1
		{
			internal int dbcc_size;
			internal int dbcc_devicetype;
			internal int dbcc_reserved;
			[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 16)]
			internal byte[] dbcc_classguid;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
			internal char[] dbcc_name;
		}

		[StructLayout(LayoutKind.Sequential)]
		internal class DEV_BROADCAST_HDR
		{
			internal int dbch_size;
			internal int dbch_devicetype;
			internal int dbch_reserved;
		}

		internal struct SP_DEVICE_INTERFACE_DATA
		{
			internal int cbSize;
			internal Guid InterfaceClassGuid;
			internal int Flags;
			internal IntPtr Reserved;
		}

		internal struct SP_DEVICE_INTERFACE_DETAIL_DATA
		{
			internal int cbSize;
			internal string DevicePath;
		}

		internal struct SP_DEVINFO_DATA
		{
			internal int cbSize;
			internal Guid ClassGuid;
			internal int DevInst;
			internal int Reserved;
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		static extern IntPtr RegisterDeviceNotification(IntPtr hRecipient, IntPtr NotificationFilter, int Flags);

		[DllImport("setupapi.dll", SetLastError = true)]
		static extern int SetupDiCreateDeviceInfoList(ref Guid ClassGuid, int hwndParent);

		[DllImport("setupapi.dll", SetLastError = true)]
		static extern int SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);

		[DllImport("setupapi.dll", SetLastError = true)]
		static extern bool SetupDiEnumDeviceInterfaces(IntPtr DeviceInfoSet, IntPtr DeviceInfoData, Guid InterfaceClassGuid, int MemberIndex, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);

		[DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, IntPtr Enumerator, IntPtr hwndParent, int Flags);

		[DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr DeviceInfoSet, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData, IntPtr DeviceInterfaceDetailData, int DeviceInterfaceDetailDataSize, ref int RequiredSize, IntPtr DeviceInfoData);

		[DllImport("user32.dll", SetLastError = true)]
		static extern bool UnregisterDeviceNotification(IntPtr Handle);
	}
}
