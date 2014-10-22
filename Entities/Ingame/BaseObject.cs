using System;
using System.Collections.Generic;
using System.Text;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class BaseObject
	{
		public int MemoryAddress;
		public ArraySegment<byte> OriginalBytes;
		public IVersion Version;
		public DatabaseModeEnum DatabaseMode;

		public BaseObject (int memoryAddress, IVersion version)
		{
			MemoryAddress = memoryAddress;
			Version = version;
			DatabaseMode = DatabaseModeEnum.Realtime;
		}

		public BaseObject(int memoryAddress, ArraySegment<byte> originalBytes, IVersion version)
		{
			MemoryAddress = memoryAddress;
			OriginalBytes = originalBytes;
			DatabaseMode = DatabaseModeEnum.Cached;
			Version = version;
		}

		public static bool operator ==(BaseObject a, BaseObject b)
		{
			if (System.Object.ReferenceEquals (a, b))
				return true;

			if (((object)a == null) || ((object)b == null))
			if ((object)a == null && (object)b == null)
				return true;
			else
				return false;

			if (a.MemoryAddress == b.MemoryAddress)
				return true;
			else
				return false;
		}

		public static bool operator !=(BaseObject a, BaseObject b)
		{
			if (!System.Object.ReferenceEquals(a, b))
				return true;

			if (((object)a == null) || ((object)b == null))
			if ((object)a == null && (object)b == null)
				return false;
			else
				return true;

			if (a.MemoryAddress != b.MemoryAddress)
				return true;
			else
				return false;
		}

		public override int GetHashCode()
		{
			return this.MemoryAddress.GetHashCode ();
		}

		public override bool Equals(object obj)
		{
			return base.GetHashCode ().Equals (obj.GetHashCode ());
		}
	}
}

