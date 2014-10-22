using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Attributes;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Club : BaseObject
	{
        public ClubOffsets ClubOffsets;
		public Club (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{
            this.ClubOffsets = new ClubOffsets(Version);
        }
		public Club (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{
            this.ClubOffsets = new ClubOffsets(Version);
        }

		public Int32 RowID {
			get {
				return PropertyInvoker.Get<Int32> (ClubOffsets.RowID, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public Int32 ID { 
			get {
				return PropertyInvoker.Get<Int32> (ClubOffsets.ID, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public Team[] Teams {
			get {
				int teamCount = ProcessManager.ReadArrayLength (MemoryAddress + ClubOffsets.Teams);
				Team[] result = new Team[teamCount];

				for(int i = 0; i < teamCount; i++) {
					int teamAddress = PropertyInvoker.Get<Int32> (ClubOffsets.Teams, OriginalBytes, MemoryAddress, DatabaseMode);
					result [i] = PropertyInvoker.GetPointer<Team> (0x0, OriginalBytes, (teamAddress + (i * 4)), DatabaseMode, Version);
				}

				return result;
			}
		}

		public string Name { 
			get {
				return PropertyInvoker.GetString (ClubOffsets.Name, 0, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public string ShortName {
			get {
				return PropertyInvoker.GetString (ClubOffsets.ShortName, 0, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		private int SixLetterNameAddress {
			get {
				return PropertyInvoker.Get<Int32> (ClubOffsets.SixLetterName, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public string SixLetterName {
			get {
				return PropertyInvoker.GetString (0x0, 0, OriginalBytes, this.SixLetterNameAddress, DatabaseMode);
			}
		}

		private int NationAddress {
			get {
				return PropertyInvoker.Get<Int32> (ClubOffsets.Nation, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public Nation Nation {
			get {
				return PropertyInvoker.GetPointer<Nation> (ClubOffsets.Nation, OriginalBytes, MemoryAddress, DatabaseMode, Version);
			}
		}

		private int BasedNationAddress {
			get {
				return PropertyInvoker.Get<Int32> (ClubOffsets.BasedNation, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public Nation BasedNation {
			get {
				return PropertyInvoker.GetPointer<Nation> (ClubOffsets.BasedNation, OriginalBytes, MemoryAddress, DatabaseMode, Version);
			}
		}

		public int ClubFinancesAddress {
			get {
				return PropertyInvoker.Get<Int32> (ClubOffsets.ClubFinances, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public ClubFinances ClubFinances {
			get {
				return PropertyInvoker.GetPointer<ClubFinances> (ClubOffsets.ClubFinances, OriginalBytes, MemoryAddress, DatabaseMode, Version);
			}
		}

		public override string ToString ()
		{
			return Name;
		}
	}
}

