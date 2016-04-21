using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Offsets
{
	public sealed class PlayerOffsets
	{

        public IVersion Version;

        public PlayerOffsets(IVersion version) {
            this.Version = version;
        }

        public short PlayerStats
        {
            get
            {
                if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
                                Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                                Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x88;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x98;
                else if (Version.GetType() == typeof(Steam_15_3_2_Mac))
                {
                    return 0xF8;
                }
                else if (Version.GetType() == typeof(Steam_15_3_2_Windows))
                    return 0x108;
                else if (Version.GetType() == typeof(Steam_16_3_0_Windows) || Version.GetType() == typeof(Steam_16_3_1_Windows))
                    return 0x102;

                return 0x90;
            }
        }

        public short Injuries
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0xD4;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0xE0;
				else if (Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows)) {
					return 0x90;
				}
                else if (Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0x9c;
                }
                else
                    return 0xDC;
            }
        }

        public short BansOffset
        {
            get
            {
                return 0xC;
            }
        }

        public short Team
        {
            get
            {
                if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0xF4;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x100;
                else if (Version.GetType() == typeof(Steam_15_3_2_Mac) ||
                    Version.GetType() == typeof(Steam_15_3_2_Windows))
                {
                    return 0xB0;
                }
                else if (Version.GetType() == typeof(Steam_16_3_0_Windows) || Version.GetType() == typeof(Steam_16_3_1_Windows))
                    return 0xBC;
                else
                    return 0xFC;
            }
        }

        public short Value
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x100;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x10C;
				else if (Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows)) {
					return 0xBC;
				}
                else
                    return 0x108;
            }
        }

        public short AskingPrice
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x104;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x110;
				else if (Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows)) {
					return 0xC0;
				}
                else
                    return 0x10C;
            }
        }

        public short Fitness
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x128;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x134;
				else if (Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows)) {
					return 0xE0;
				}
                else if (Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0xec;
                }
                else
                    return 0x130;
            }
        }

        public short Jadedness
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x12A;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x136;
				else if (Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows)) {
					return 0xE2;
				}
                else if (Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0xee;
                }
                else
                    return 0x132;
            }
        }

        public short Condition
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x12C;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x138;
				else if (Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows)) {
					return 0xE4;
				}
                else if (Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0xf0;
                }
                else
                    return 0x134;
            }
        }

        public short HomeReputation
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x12E;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x13A;
				else if (Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows)) {
					return 0xE6;
				}
                else if (Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0xf2;
                }
                else
                    return 0x136;
            }
        }

        public short CurrentReputation
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x130;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x13C;
				else if (Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows)) {
					return 0xE8;
				}
                else if (Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0xf4;
                }
                else
                    return 0x138;
            }
        }

        public short WorldReputation
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x132;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x13E;
				else if (Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows)) {
					return 0xEA;
				}
                else if (Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0xf6;
                }
                else
                    return 0x13A;
            }
        }

        public short CA
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x134;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x140;
				else if (Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows)) {
					return 0xEC;
				}
                else if (Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0xf8;
                }
                else
                    return 0x13C;
            }
        }

        public short PA
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x136;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x142;
				else if (Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows)) {
					return 0xEE;
				}
                else if (Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0xfa;
                }
                else
                    return 0x13E;
            }
        }

        public short Weight
        {
            get
            {
                if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x138;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x144;
                else if (Version.GetType() == typeof(Steam_15_3_2_Mac) ||
                    Version.GetType() == typeof(Steam_15_3_2_Windows))
                {
                    return 0xF0;
                }
                else if (Version.GetType() == typeof(Steam_16_3_0_Windows) || Version.GetType() == typeof(Steam_16_3_1_Windows))
                    return 0xfc;
                else
                    return 0x140;
            }
        }

        public short Height
        {
            get
            {
                if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x13A;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x146;
                else if (Version.GetType() == typeof(Steam_15_3_2_Mac) ||
                    Version.GetType() == typeof(Steam_15_3_2_Windows))
                {
                    return 0xF2;
                }
                else if (Version.GetType() == typeof(Steam_16_3_0_Windows) || Version.GetType() == typeof(Steam_16_3_1_Windows))
                    return 0xfe;
                else
                    return 0x142;
            }
        }

		public short InternationalApps
		{
			get
			{
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux) ||
					Version.GetType() == typeof(Steam_15_3_2_Mac) ||
					Version.GetType() == typeof(Steam_15_3_2_Windows))
					return 0x200;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
					return 0x214;
                else if (Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0xe0;
                }
                else
					return 0x240;
			}
		}

		public short U21InternationalApps
		{
			get
			{
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux) ||
					Version.GetType() == typeof(Steam_15_3_2_Mac) ||
					Version.GetType() == typeof(Steam_15_3_2_Windows))
					return 0x201;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
					return 0x215;
                else if (Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0xe1;
                }
                else
					return 0x241;
			}
		}

		public short InternationalGoals
		{
			get
			{
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux) ||
					Version.GetType() == typeof(Steam_15_3_2_Mac) ||
					Version.GetType() == typeof(Steam_15_3_2_Windows))
					return 0x202;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
					return 0x216;
                else if (Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0xe2;
                }
                else
					return 0x242;
			}
		}

		public short U21InternationalGoals
		{
			get
			{
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux) ||
					Version.GetType() == typeof(Steam_15_3_2_Mac) ||
					Version.GetType() == typeof(Steam_15_3_2_Windows))
					return 0x203;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
					return 0x217;
                else if (Version.GetType() == typeof(Steam_16_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_1_Windows))
                {
                    return 0xe3;
                }
                else
					return 0x243;
			}
		}

		public short RowID
		{
			get
			{
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux) ||
					Version.GetType() == typeof(Steam_15_3_2_Mac) ||
					Version.GetType() == typeof(Steam_15_3_2_Windows))
					return 0x20C;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
					return 0x220;
				else
					return 0x154;
			}
		}

		public short ID
		{
			get
			{
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux) ||
					Version.GetType() == typeof(Steam_15_3_2_Mac) ||
					Version.GetType() == typeof(Steam_15_3_2_Windows))
					return 0x210;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
					return 0x224;
				else
					return 0x158;
			}
		}
	}
}

