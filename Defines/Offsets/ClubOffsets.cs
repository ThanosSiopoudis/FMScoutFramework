using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Offsets
{
	public sealed class ClubOffsets
	{
        public IVersion Version;

        public ClubOffsets(IVersion version)
        {
            this.Version = version;
        }

        // Consts are the same for every version
		public const short RowID			= 0x4;
		public const short ID				= 0x8;
		public const short Teams 			= 0x10;
        public const short ClubDetailsOne   = 0x50;

        public short Fullname
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux) ||
                    Version.GetType() == typeof(Steam_15_2_1_Windows) ||
                    Version.GetType() == typeof(Steam_15_3_2_Windows) ||
                    Version.GetType() == typeof(Steam_16_2_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0x54;
                }
                else
                {
                    return 0x64;
                }
            }
        }

        public short Name
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux) ||
                    Version.GetType() == typeof(Steam_15_2_1_Windows) ||
                    Version.GetType() == typeof(Steam_15_3_2_Windows) ||
                    Version.GetType() == typeof(Steam_16_2_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0x54;
                }
                else
                {
                    return 0x68;
                }
            }
        }

        public short ShortName
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_15_2_1_Windows) ||
                    Version.GetType() == typeof(Steam_15_3_2_Windows) ||
                    Version.GetType() == typeof(Steam_16_2_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0x58;
                }
                else
                {
                    return 0x6C;
                }
            }
        }

        public short Nation
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux) ||
                    Version.GetType() == typeof(Steam_15_2_1_Windows) ||
                    Version.GetType() == typeof(Steam_15_3_2_Windows) ||
                    Version.GetType() == typeof(Steam_16_2_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0x60;
                }
                else
                {
                    return 0x74;
                }
            }
        }

        public short BasedNation
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                {
                    return 0x68;
                }
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows) ||
                    Version.GetType() == typeof(Steam_15_3_2_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0x6C;
                }
                else
                {
                    return 0x7C;
                }
            }
        }

        public short City
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                {
                    return 0x6C;
                }
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows) ||
                    Version.GetType() == typeof(Steam_15_3_2_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0x70;
                }
                else
                {
                    return 0x80;
                }
            }
        }

        public short ClubDetailsTwo
        {
            get
            {
                if (Version.GetType() == typeof(Steam_15_2_1_Windows) ||
                    Version.GetType() == typeof(Steam_15_3_2_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0x74;
                }
                else
                {
                    return 0x70;
                }
            }
        }

        public short ClubSponshorshipDeals
        {
            get
            {
                if (Version.GetType() == typeof(Steam_15_2_1_Windows) ||
                    Version.GetType() == typeof(Steam_15_3_2_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0x8C;
                }
                else
                {
                    return 0x88;
                }
            }
        }

        public short ClubFinances
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux))
                {
                    return 0x98;
                }
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows) ||
                    Version.GetType() == typeof(Steam_15_3_2_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0x9C;
                }
                else
                {
                    return 0xB0;
                }
            }
        }
	}
}
