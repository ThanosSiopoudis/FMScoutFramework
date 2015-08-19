using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Entities.InGame
{
    public class NationTaxRule : BaseObject
    {
        public NationTaxRule (int memoryAddress, IVersion version)
            : base(memoryAddress, version)
        { }
        public NationTaxRule (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version)
            : base(memoryAddress, originalBytes, version)
        { }
    }
}

