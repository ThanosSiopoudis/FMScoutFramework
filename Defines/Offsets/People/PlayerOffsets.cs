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
                return 0x117;
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
                else
                    return 0xFC;
            }
        }

        public short Value
        {
            get
            {
                return 0xCC;
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
                else
                    return 0x13A;
            }
        }

        public short CA
        {
            get
            {
                return 0xFC;
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
                else
                    return 0x142;
            }
        }

        public short DateOfBirth
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x150;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x160;
                else
                    return 0x178;
            }
        }

        public short Nickname
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x164;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x174;
                else
                    return 0x180;
            }
        }

      
        public short CityOfBirth
        {
            get
            {
                if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x168;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x178;
                else
                    return 0x0;
            }
        }

        public short Nationality
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x16C;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x17C;
                else
                    return 0x194;
            }
        }

        public short Attributes
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x170;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x180;
                else
                    return 0x198;
            }
        }

        public short Contract
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x198;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x1A8;
                else
                    return 0x1C4;
            }
        }

        public short Club
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x200;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x200;
                else
                    return 0x22C;
            }
        }

        public short InternationalApps
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x204;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x214;
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
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x205;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x215;
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
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x206;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x216;
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
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x207;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x217;
                else
                    return 0x243;
            }
        }
	}
}

