using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Offsets
{
    public sealed class LeagueOffsets
    {
        public IVersion Version;

        public LeagueOffsets(IVersion version)
        {
            this.Version = version;
        }

        public const short RowID = 0x4;
        public const short ID = 0x8;
        public const short Teams = 0x10;
        public const short RivalNations = 0x28;

        public short Name
        {
            get
            {
                return 0x34;
            }
        }

        public const short ShortName = 0x38;
    }
}

