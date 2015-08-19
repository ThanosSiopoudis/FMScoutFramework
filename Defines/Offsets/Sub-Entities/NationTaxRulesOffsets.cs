using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Offsets
{
    public sealed class NationTaxRulesOffsets
    {
        public IVersion Version;

        public NationTaxRulesOffsets (IVersion version)
        {
            this.Version = version;
        }

        public const short Percentage = 0x0;
        public const short LowerAmount = 0x4;
        public const short UpperAmount = 0x8;
        public const short CappedAmount = 0xC;
        public const short Year = 0x10;
        public const short PersonType = 0x12;
        public const short Type = 0x13;
        public const short TimeFrameYears = 0x14;
        public const short DivisionLevel = 0x15;
    }
}

