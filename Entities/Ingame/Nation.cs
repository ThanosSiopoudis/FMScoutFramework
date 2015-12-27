using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Entities.InGame.Interfaces;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Nation : BaseObject, INation
    {
        public NationOffsets NationOffsets;
		public Nation (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{
            this.NationOffsets = new NationOffsets(Version);
        }
		public Nation (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{
            this.NationOffsets = new NationOffsets(Version);
        }

        public Int32 RowID {
            get {
                return ProcessManager.ReadInt32 (MemoryAddress + NationOffsets.RowID);
            }
        }

		public Int32 ID {
			get {
				return ProcessManager.ReadInt32 (MemoryAddress + NationOffsets.ID);
			}
		}

        public Team[] Teams
        {
            get
            {
                int teamCount = ProcessManager.ReadArrayLength(MemoryAddress + NationOffsets.Teams);
                Team[] result = new Team[teamCount];

                for (int i = 0; i < teamCount; i++)
                {
                    int teamAddress = PropertyInvoker.Get<Int32>(NationOffsets.Teams, OriginalBytes, MemoryAddress, DatabaseMode);
                    result[i] = PropertyInvoker.GetPointer<Team>(0x0, OriginalBytes, (teamAddress + (i * 4)), DatabaseMode, Version);
                }

                return result;
            }
        }

        public RivalNation[] RivalNations
        {
            get
            {
                int nationCount = ProcessManager.ReadArrayLength(MemoryAddress + NationOffsets.RivalNations, 0xC);
                RivalNation[] result = new RivalNation[nationCount];

                for (int i = 0; i < nationCount; i++)
                {
                    int nationAddress = PropertyInvoker.Get<Int32>(NationOffsets.RivalNations, OriginalBytes, MemoryAddress, DatabaseMode);
                    result[i] = new RivalNation((nationAddress + (i * 0xC)), Version);
                }

                return result;
            }
        }

        public string Name {
            get {
                return PropertyInvoker.GetString(NationOffsets.Name, -1, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public string ShortName {
            get {
                return PropertyInvoker.GetString (NationOffsets.ShortName, -1, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public string ThreeLetterName {
            get {
                return PropertyInvoker.GetString (NationOffsets.ThreeLetterName, -1, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public string NationalityName {
            get {
                return PropertyInvoker.GetString (NationOffsets.Nationality, -1, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        // TODO: SpokenLanguages



		public override string ToString ()
		{
			return Name;
		}
	}
}

