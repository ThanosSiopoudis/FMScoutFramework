using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Offsets
{
	public sealed class PersonOffsets
	{

        public IVersion Version;

        public PersonOffsets(IVersion version)
        {
            this.Version = version;
        }

      
        public short Fullname
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x154;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x164;
                else
                    return 0x17C;
            }
        }

        public short Nickname
        {
            get
            {
                return 0x40;
            }
        }

        public short Firstname
        {
            get
            {
                return 0x38;
            }
        }

        public short Lastname
        {
            get
            {
                return 0x3C;
            }
        }

     

        public short RowID
        {
            get
            {
                return 0x04;
            }
        }

        public short ID
        {
            get
            {
                return 0x08;
            }
        }

        public int DateOfBirth
        {
            get
            {
                return 0x2C;
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
					return 0x74;
			}
		}
        public int Nationality
        {
            get
            {
                return 0x48;
            }
        }
    }
}

