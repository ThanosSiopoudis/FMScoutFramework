using FMScoutFramework.Core.Entities.GameVersions;
using System;

namespace FMScoutFramework.Core.Offsets
{
	public sealed class ContractOffsets
	{
        public IVersion Version;

        public ContractOffsets(IVersion Version)
        {
            this.Version = Version;
        }

        public const short Person = 0x4;
		public const short Team = 0x8;
		public const short JobType = 0xC;
		public const short Wage = 0x14;
		public const short DateStarted = 0x20;
		public const short DateExpires = 0x24;
		public const short SquadStatus = 0x30;
		public const short TransferStatus = 0x32;
		public const short Clauses = 0x3C;
		public const short Bonuses = 0x48;
		public const short Type = 0x5D;

        public short SquadNumber
        {
            get
            {
                if (Version.GetType() == typeof(Steam_16_3_0_Windows) || Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0x39;
                }

                return 0x35;
            }
        }
	}
}

