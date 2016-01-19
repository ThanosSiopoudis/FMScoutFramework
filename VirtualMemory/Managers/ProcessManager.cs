using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Linq.Expressions;
using System.Diagnostics;

namespace FMScoutFramework.Core.Managers
{
	public static class ProcessManager
	{
		public static FMProcess fmProcess = null;
		public static string FMVersion = null;
		public static string FMVersionShort = null;

		public static FMProcess FMProcess
		{
			get { return fmProcess; }
			set { fmProcess = value; }
		}

		#if WINDOWS
		public static int GetProcessEndPoint(IntPtr process) {
			int bytesRead = 0;
			int memoryAddress = 0x7fffffff;
			int num3 = 0x1000000;
			for (int i = 1; i <= 7; i++) {
				ReadProcessMemory (process, memoryAddress, 1, out bytesRead);
				while (bytesRead == 0) {
					memoryAddress -= num3;
					ReadProcessMemory (process, memoryAddress, 1, out bytesRead);
				}
				memoryAddress += num3;
				num3 /= 0x10;
			}
			return memoryAddress;
		}
		#endif
		#if MAC
		public static int GetProcessEndPoint(int pid) {
			int memoryAddress = 0x7FFFFFFF;
			int num3 = 0x1000000;
			bool readable = false;
			for (int i = 1; i <= 7; i++) {
				readable = ProcessMemoryAPI.CanReadAtAddress (pid, (UInt64)memoryAddress, 1);
				while (!readable) {
					memoryAddress -= num3;
					readable = ProcessMemoryAPI.CanReadAtAddress (pid, (UInt64)memoryAddress, 1);
				}
				memoryAddress += num3;
				num3 /= 0x10;
			}
			return memoryAddress;
		}
		#endif
		#region ReadProcessMemoryExtensions

		#if WINDOWS
		private static byte[] ReadProcessMemory(IntPtr process, int memoryAddress, uint bytesToRead, out int bytesRead)
		{
			IntPtr ptr;
			byte[] buffer = new byte[bytesToRead];
			ProcessMemoryAPI.ReadProcessMemory(process, (IntPtr)memoryAddress, buffer, bytesToRead, out ptr);
			bytesRead = ptr.ToInt32 ();
			return buffer;
		}

		public static byte[] ReadProcessMemory(int memoryAddress, uint bytesToRead)
		{
			if (memoryAddress > 0) {
				int num;
				if (bytesToRead <= (32 * 1024 * 1024))
					return ReadProcessMemory (memoryAddress, bytesToRead, out num);
			}
			return new byte[4];
		}

        public static byte[] ReadProcessMemory(int memoryAddress, uint bytesToRead, out int bytesRead)
        {
            IntPtr ptr;
            byte[] buffer = new byte[bytesToRead];
            ProcessMemoryAPI.ReadProcessMemory(FMProcess.Pointer, (IntPtr)memoryAddress, buffer, bytesToRead, out ptr);
            bytesRead = ptr.ToInt32();
            return buffer;
        }
		#endif
		#if LINUX
		private static byte[] ReadProcessMemory(int pid, int address, int length)
		{
			byte[] buffer = new byte[length];
			if (address > fmProcess.BaseAddress) {
				ProcessMemoryAPI.ReadProcessMemory (pid, (ulong)address, (ulong)length, buffer);
			}
			return buffer;
		}

		public static byte[] ReadProcessMemory(int address, int length)
		{
			byte[] buffer = new byte[length];
			if (ProcessMemoryAPI.ReadProcessMemory (FMProcess.Process.Id, (ulong)address, (ulong)length, buffer) == 0)
				; // TODO: When things are mature enough, we should add an exception here
			return buffer;
		}
		#endif
		#if MAC
		public static byte[] ReadProcessMemory(int pid, int address, int length)
		{
			byte[] buffer = new byte[length];
			if (address > fmProcess.BaseAddress) {
				IntPtr result = ProcessMemoryAPI.ReadProcessBytes (pid, (UInt64)address, length);
				Marshal.Copy (result, buffer, 0, length);
			}
			return buffer;
		}

		public static byte[] ReadProcessMemory(int address, int length) {
			byte[] buffer = new byte[length];
			if (address > fmProcess.BaseAddress) {
				IntPtr result = ProcessMemoryAPI.ReadProcessBytes (FMProcess.Process.Id, (UInt64)address, length);
				Marshal.Copy (result, buffer, 0, length);
			}
			return buffer;
		}
		#endif

		public static byte ReadByte(int address)
		{
			return ReadProcessMemory (address, 1) [0];
		}

		public static sbyte ReadSByte(int address)
		{
			return (sbyte)ReadProcessMemory (address, 1) [0];
		}

		public static Int16 ReadInt16(int address)
		{
			byte[] buffer = ReadProcessMemory (address, 2);
			return ReadInt16 (buffer, 0);
		}

		public static float ReadFloat(int address)
		{
			byte[] buffer = ReadProcessMemory (address, 4);
			return ReadFloat (buffer, 0);
		}

        public static double ReadDouble(int address) {
            byte[] buffer = ReadProcessMemory (address, 4);
            return ReadDouble (buffer, 0);
        }

		public static Int32 ReadInt32(int address)
		{
			byte[] buffer = ReadProcessMemory (address, 4);
			return ReadInt32 (buffer, 0);
		}

		public static UInt32 ReadUInt32(int address)
		{
			byte[] buffer = ReadProcessMemory ((int)address, 4);
			return ReadUInt32 (buffer, 0);
		}

		public static ushort ReadUInt16(int address)
		{
			byte[] buffer = ReadProcessMemory (address, 2);
			return ReadUInt16 (buffer, 0);
		}

		public static DateTime ReadDateTime(int address)
		{
			int days = (ReadInt16 (address) & 0x1FF);
			int years = ReadInt16 (address + 0x2);
			if (days > 0 && days < 366 && years > 1900 && years < 2150) {
				return FMScoutFramework.Core.Converters.DateConverter.FromFmDateTime ((days - 1), years);
			}
			return new DateTime (1900, 1, 1);
		}

		public static string ReadString(int currentAddress, int? addBufferIndex, bool isRead)
		{
			return ReadString (currentAddress, addBufferIndex, 0, isRead);
		}

		public static string ReadString(int currentAddress, int? addBufferIndex)
		{
			return ReadString (currentAddress, addBufferIndex, 0, false);
		}

		private static Dictionary<string, string> readStringCache = new Dictionary<string, string>();
		public static string ReadString(int currentAddress, int? addBufferIndex, int offset, bool isRead)
		{
			string cacheKey = string.Format ("{0}.{1}.{2}.{3}", currentAddress, addBufferIndex ?? -1, offset, isRead);
			if (!readStringCache.ContainsKey (cacheKey)) {
				if (!isRead)
					currentAddress = ProcessManager.ReadInt32 (currentAddress);

				if (addBufferIndex >= 0)
					currentAddress = ProcessManager.ReadInt32 (currentAddress + (int)addBufferIndex);

				string str = "";

				// Skip the first byte
				currentAddress += 0x1;
				// Get the string Length
				int length = (int)ProcessManager.ReadInt16(currentAddress);
				if (length <= 0) {
					return "-";
				}
				length = length * 2;
				currentAddress += 0x3;

                #if WINDOWS
                byte[] buffer = ProcessManager.ReadProcessMemory(currentAddress, (uint)length);
                #endif

				#if LINUX || MAC
				byte[] buffer = ProcessManager.ReadProcessMemory (currentAddress, length);
                #endif
				if (buffer.Length < length) {
					return "";
				}
				str = UnicodeEncoding.Unicode.GetString (buffer);

				readStringCache.Add (cacheKey, str);
			}
			return readStringCache [cacheKey];
		}

		public static int ReadArrayLength(int currentAddress) {
			return ReadArrayLength (currentAddress, 0x4);
		}

		public static int ReadArrayLength(int currentAddress, int objectLength)
		{
			int addressOne = ProcessManager.ReadInt32 (currentAddress);
			int addressTwo = ProcessManager.ReadInt32 (currentAddress + 0x4);

			return ((addressTwo - addressOne) / objectLength);
		}
		#endregion

		#region ReadFromBuffer
		private static Dictionary<int, string> stringCache = new Dictionary<int, string> ();
		public static string ReadString(ArraySegment<byte> buffer, int offset, int additionalStringOffset)
		{
			int stringPointer = ReadInt32 (buffer.Array, offset + buffer.Offset);
			if (!stringCache.ContainsKey (stringPointer))
				stringCache.Add (stringPointer, ReadString (stringPointer, -1, additionalStringOffset, true));

			return stringCache [stringPointer];
		}

		public static short ReadInt16(byte[] buffer, int offset)
		{
			return BitConverter.ToInt16 (buffer, offset);
		}

		public static Int32 ReadInt32(byte[] buffer, int offset)
		{
			return BitConverter.ToInt32 (buffer, offset);
		}

		public static ushort ReadUInt16(byte[] buffer, int offset)
		{
			return BitConverter.ToUInt16 (buffer, offset);
		}

		public static UInt32 ReadUInt32(byte[] buffer, int offset)
		{
			return BitConverter.ToUInt32 (buffer, offset);
		}

        public static double ReadDouble(byte[] buffer, int offset)
        {
            return BitConverter.ToDouble (buffer, offset);
        }

		public static float ReadFloat(byte[] buffer, int offset)
		{
			return BitConverter.ToSingle (buffer, offset);
		}

		public static int GetAddress(byte[] buffer, int index) 
		{
			int num = 0;
			try {
				num += buffer[index];
				num += buffer[index + 1] * 0x100;
				num += buffer[index + 2] * 0x10000;
				num += buffer[index + 3] * 0x1000000;
			}
			catch {
				return 0;
			}
			return num;
		}
		#endregion

        #region WriteProcessMemory
        #if WINDOWS
        public static int WriteProcessMemory(int memoryaddress, byte[] buffer, uint bytesToWrite)
        {
            IntPtr ptr;
            ProcessMemoryAPI.WriteProcessMemory(FMProcess.Pointer, (IntPtr)memoryaddress, buffer, bytesToWrite, out ptr);
            return ptr.ToInt32();
        }
        #endif
		#if LINUX || MAC
        public static int WriteProcessMemory(int memoryaddress, byte[] buffer, uint bytesToWrite)
        {
            return 0;
        }
        #endif

        public static void WriteByte(byte value, int address)
        {
            byte[] buffer = new byte[] { value };
            WriteProcessMemory(address, buffer, 1);
        }

        public static void WriteDateTime(DateTime value, int address)
        {
			WriteInt32 (Converters.DateConverter.ToFmDateTime (value), address, true);
        }

        public static void WriteInt16(int value, int address)
        {
            WriteInt16(value, address, false);
        }

        public static void WriteInt16(int value, int address, bool reverse)
        {
            byte[] buffer = new byte[2];
            if (!reverse)
            {
                buffer[0] = (byte)(value & 0xFF);
                buffer[1] = (byte)((value & 0xFF00) >> 8);
            }
            else
            {
                buffer[1] = (byte)(value & 0xFF);
                buffer[0] = (byte)((value & 0xFF00) >> 8);
            }
            WriteProcessMemory(address, buffer, 2);
        }

        public static void WriteInt32(int value, int address)
        {
            WriteInt32(value, address, false);
        }

        public static void WriteInt32(int value, int address, bool reverse)
        {
            byte[] buffer = new byte[4];
            if (!reverse)
            {
                buffer[0] = (byte)(value & 0xFF);
                buffer[1] = (byte)((value & 0xFF00) >> 8);
                buffer[2] = (byte)((value & 0xFF0000) >> 0x10);
                buffer[3] = (byte)((value & 0xFF000000) >> 0x18);
            }
            else
            {
                buffer[3] = (byte)(value & 0xFF);
                buffer[2] = (byte)((value & 0xFF00) >> 8);
                buffer[1] = (byte)((value & 0xFF0000) >> 0x10);
                buffer[0] = (byte)((value & 0xFF000000) >> 0x18);
            }
            WriteProcessMemory(address, buffer, 4);
        }

        public static void WriteSByte(sbyte value, int address)
        {
            byte[] buffer = new byte[] { (byte)value };
            WriteProcessMemory(address, buffer, 1);
        }

        public static void WriteString(byte[] value, int address)
        {
            WriteProcessMemory(address, value, 4);
        }
        #endregion

        static Dictionary<Type, Func<byte[], int, object>> readFromBufferCache = new Dictionary<Type, Func<byte[], int, object>> ();
		private static readonly object ReadFromBufferLock = new object();
		public static object ReadFromBuffer(byte[] bytes, int offset, Type type)
		{
			bool exists;
			Func<byte[], int, object> activeDelegate = null;

			lock (ReadFromBufferLock) {
				exists = readFromBufferCache.ContainsKey (type);

				if (exists)
					activeDelegate = readFromBufferCache [type];
			}

			if (!exists) {
				ParameterExpression bts = Expression.Parameter (typeof(byte[]), "bytes");
				ParameterExpression ofs = Expression.Parameter (typeof(int), "offset");
				MethodCallExpression mce = Expression.Call (
					ObjectManager.GetMethodInfo (type),
					bts, ofs);
				LambdaExpression le = Expression.Lambda (Expression.Convert (mce, typeof(object)), bts, ofs);

				var compiled = (Func<byte[], int, object>)le.Compile ();
				lock (ReadFromBufferLock) {
					readFromBufferCache.Add (type, compiled);
				}
				activeDelegate = compiled;
			}

			return activeDelegate.Invoke (bytes, offset);
		}
	}
}

