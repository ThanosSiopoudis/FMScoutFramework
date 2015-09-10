using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Attributes;

namespace FMScoutFramework.Core.Entities.InGame
{
    public class League : BaseObject
    {
        public LeagueOffsets LeagueOffsets; 
        public League(int memoryAddress, IVersion version)
            : base(memoryAddress, version)
        {
            this.LeagueOffsets = new LeagueOffsets(Version);
        }
        public League(int memoryAddress, ArraySegment<byte> originalBytes, IVersion version)
            : base(memoryAddress, originalBytes, version)
        {
            this.LeagueOffsets = new LeagueOffsets(Version);
        }

        public int RowID
        {
            get
            {
                return ProcessManager.ReadInt32(MemoryAddress + LeagueOffsets.RowID);
            }
        }

        public int ID
        {
            get
            {
                return ProcessManager.ReadInt32(MemoryAddress + LeagueOffsets.ID);
            }
        }

        public string Name
        {
            get
            {
                return PropertyInvoker.GetString(LeagueOffsets.Name, -1, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public string ShortName
        {
            get
            {
                return PropertyInvoker.GetString(LeagueOffsets.ShortName, -1, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

