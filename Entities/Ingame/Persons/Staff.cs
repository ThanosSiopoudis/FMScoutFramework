using System;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Staff : Person
	{
		private StaffOffsets StaffOffsets;
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

		protected override int PersonAddress {
			get {
				return StaffAddress + StaffOffsets.PersonAddress;
			}
		}

		private int StaffAddress {
			get {
				return MemoryAddress + Version.PersonOffsets.Staff;
			}
		}

		public Int32 ID {
			get {
				return PropertyInvoker.Get<Int32>(StaffOffsets.ID, OriginalBytes, StaffAddress, DatabaseMode);
			}
		}

		public Int32 RowID {
			get {
				return PropertyInvoker.Get<Int32>(StaffOffsets.RowID, OriginalBytes, StaffAddress, DatabaseMode);
			}
		}
	}
}

