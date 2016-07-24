using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Offsets
{
	public sealed class TeamOffsets
	{
        public IVersion Version;

        public TeamOffsets(IVersion version)
        {
            this.Version = version;
        }

		public const short RowID				= 0x4;
		public const short ID					= 0x8;
		public const short Club					= 0x10;
		public const short PreviousReputation	= 0x1A;
		public const short TeamType 			= 0x1C;
		public const short Manager				= 0x4C;

        public short Players
        {
            get
            {
                if (Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_2_Windows))
                {
                    return 0x24;
                }
                else
                {
                    return 0x28;
                }
            }
        }

        public short Stadium
        {
            get
            {
                if (Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_2_Windows))
                {
                    return 0x40;
                }
                else
                {
                    return 0x48;
                }
            }
        }

        public short Reputation
        {
            get
            {
                if (Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_2_Windows))
                {
                    return 0x64;
                }
                else
                {
                    return 0x68;
                }
            }
        }
	}
}

