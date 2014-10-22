using System;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Staff : BaseObject
	{
		public StaffOffsets StaffOffsets;
		public Staff (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{	
			this.StaffOffsets = new StaffOffsets (version);
		}
		public Staff (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{	
			this.StaffOffsets = new StaffOffsets (version);
		}

		public Int32 ID {
			get {
				return PropertyInvoker.Get<Int32>(StaffOffsets.ID, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public Int32 RowID {
			get {
				return PropertyInvoker.Get<Int32>(StaffOffsets.RowID, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public string Fullname {
			get {
				return PropertyInvoker.GetString(StaffOffsets.Fullname, 0x0, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public string FirstName {
			get {
				return PropertyInvoker.GetString(StaffOffsets.FirstName, 0xC, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public string LastName {
			get {
				return PropertyInvoker.GetString (StaffOffsets.LastName, 0xC, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}
	}
}

