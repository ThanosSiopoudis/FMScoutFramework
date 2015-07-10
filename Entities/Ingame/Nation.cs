using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Attributes;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Nation : BaseObject
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

		public Int32 ID {
			get {
				return ProcessManager.ReadInt32 (MemoryAddress + NationOffsets.ID);
			}
		}

		public string Name {
			get {
				return ProcessManager.ReadString (MemoryAddress + NationOffsets.Name, -1);
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

		public override string ToString ()
		{
			return Name;
		}
	}
}

