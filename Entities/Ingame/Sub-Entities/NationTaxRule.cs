using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Entities.InGame.Interfaces;

namespace FMScoutFramework.Core.Entities.InGame
{
    public class NationTaxRule : BaseObject, INationTaxRule
    {
        public NationTaxRule (int memoryAddress, IVersion version)
            : base(memoryAddress, version)
        { }
        public NationTaxRule (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version)
            : base(memoryAddress, originalBytes, version)
        { }
    }
}

