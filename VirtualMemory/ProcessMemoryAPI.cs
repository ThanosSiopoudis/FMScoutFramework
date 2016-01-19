using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace FMScoutFramework
{
	internal sealed class ProcessMemoryAPI
	{
		#if MAC
		[DllImport("libprocessmemoryapi.dylib")]
		public static extern IntPtr ReadProcessBytes (int pid, UInt64 address, int size);

		[DllImport("libprocessmemoryapi.dylib")]
		public static extern bool CanReadAtAddress(int pid, UInt64 address, int size);
		#endif
		#if LINUX
		[DllImport("libprocessmemoryinterface.1.0.so")]
		public static extern int ReadProcessMemory(int pid, ulong address, ulong length, [In, Out]byte[] buffer);

		public static bool GetBaseAddress (uint ProcessID, out uint buffer, out uint bufferend, out uint heap, out uint endaddress)
		{
			// Get access to the mem map file
			string[] memoryMap = null;
			try
			{
				memoryMap = File.ReadAllLines ("/proc/" + ProcessID.ToString () + "/maps");
			}
			catch {
				buffer = 0;
				bufferend = 0;
				heap = 0;
				endaddress = 0;
				return false;
			}

			// Find the heap and get the starting offset of the block before it
			string staticBlockAddressLine = "";
			string heapAddressLine = "";
			int i = 0;
			foreach (string line in memoryMap) {
				if (line.Contains ("[heap]")) {
					heapAddressLine = memoryMap [i];
					staticBlockAddressLine = memoryMap [i - 3];
					break;
				}
				i++;
			}

			if (staticBlockAddressLine.Length <= 0) {
				buffer = 0;
				bufferend = 0;
				heap = 0;
				endaddress = 0;
				return false;
			}

			// Now extract the starting address from the memory map
			try {
				MatchCollection matches = Regex.Matches(staticBlockAddressLine, "([0-9a-f]+)");
				String baseAddress = matches[0].ToString();
				buffer = UInt32.Parse (baseAddress, System.Globalization.NumberStyles.HexNumber);
				String baseEndAddress = matches[1].ToString();
				bufferend = UInt32.Parse (baseEndAddress, System.Globalization.NumberStyles.HexNumber);

				matches = Regex.Matches(heapAddressLine, "([0-9a-f]+)");
				String heapAddress = matches[0].ToString();
				heap = UInt32.Parse(heapAddress, System.Globalization.NumberStyles.HexNumber);
				String end = matches[1].ToString();
				endaddress = UInt32.Parse(end, System.Globalization.NumberStyles.HexNumber);
			}
			catch {
				buffer = 0;
				bufferend = 0;
				heap = 0;
				endaddress = 0;
				return false;
			}

			return true;
		}
		#endif
		#if WINDOWS

		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

		[DllImport("kernel32.dll")]
		public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);
		#endif
	}
}

