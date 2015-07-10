using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Attributes;

namespace FMScoutFramework.Core.Entities.InGame
{
    public class RivalNation : BaseObject
    {
        public RivalNationOffsets RivalNationOffsets;
        public RivalNation (int memoryAddress, IVersion version)
            : base(memoryAddress, version) 
        {
                this.RivalNationOffsets = new RivalNationOffsets(version);
        }
        public RivalNation(int memoryAddress, ArraySegment<byte>originalBytes, IVersion version)
            : base(memoryAddress, originalBytes, version)
        {
            this.RivalNationOffsets = new RivalNationOffsets(version);
        }

        private int RivalNationAddress
        {
            get
            {
                return PropertyInvoker.Get<Int32>(RivalNationOffsets.NationAddress, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public Nation Nation
        {
            get
            {
                return PropertyInvoker.GetPointer<Nation>(RivalNationOffsets.NationAddress, OriginalBytes, MemoryAddress, DatabaseMode, Version);
            }
        }

        public Byte Level
        {
            get
            {
                return PropertyInvoker.Get<Byte>(RivalNationOffsets.Level, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public override string ToString()
        {
            return this.Nation.Name;
        }
    }
}
