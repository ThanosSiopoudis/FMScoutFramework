using FMScoutFramework.Core.Entities.GameVersions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FMScoutFramework.Defines.Offsets
{
    public sealed class CityOffsets
    {
        public IVersion Version;

        public CityOffsets(IVersion version)
        {
            this.Version = version;
        }

        public const short RowID = 0x4;
        public const short ID = 0x8;
        public const int Nation = 0x18;
        public const short Name = 0x10;
        public const short Attraction = 0x38;
        public const short Latitude = 0x24;
        public const short Longitude = 0x28;
        public const short Altitude = 0x34;
    }
}
