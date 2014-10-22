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

        public short Fullname
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
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
					Version.GetType() == typeof(Steam_14_3_1_Linux))
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
					Version.GetType() == typeof(Steam_14_3_0_Mac))
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
					Version.GetType() == typeof(Steam_14_3_1_Linux))
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
                else
                {
                    return 0x80;
                }
            }
        }

        public short SixLetterName
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                {
                    return 0x70;
                }
                else
                {
                    return 0x84;
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
                else
                {
                    return 0xB0;
                }
            }
        }
	}
}
