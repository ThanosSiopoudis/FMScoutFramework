using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Offsets
{
	public sealed class StaffOffsets
	{

		public IVersion Version;

		public StaffOffsets(IVersion version) {
			this.Version = version;
		}

        public short StaffAttributes
        {
            get
            {
                if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x4;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x4;
                else
                    return 0x0;
            }
        }

        public short HomeReputation
        {
            get
            {
                if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x68;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x70;
                else
                    return 0x0;
            }
        }

        public short CurrentReputation
        {
            get
            {
                if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x6A;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x72;
                else
                    return 0x0;
            }
        }

        public short WorldReputation
        {
            get
            {
                if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x6C;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x72;
                else
                    return 0x0;
            }
        }

        public short CurrentAbility
        {
            get
            {
                if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x6E;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x76;
                else
                    return 0x0;
            }
        }

        public short PotentialAbility
        {
            get
            {
                if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x70;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x78;
                else
                    return 0x0;
            }
        }

        public short RowID
        {
            get
            {
                if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x80;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x88;
                else
                    return 0x0;
            }
        }

        public short ID
        {
            get
            {
                if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0x84;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x8C;
                else
                    return 0x0;
            }
        }

		public short DateOfBirth {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
					Version.GetType () == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0x9C;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0xA4;
				else
					return 0x0;
			}
		}

		public short FirstName {
			get {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0xA8;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0xB0;
				else
					return 0x0;
			}
		}

		public short LastName {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
					Version.GetType () == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0xAC;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0xB4;
				else
					return 0x0;
			}
		}

        public short CommonName
        {
            get
            {
                if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux))
                    return 0xB0;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0xB8;
                else
                    return 0x0;
            }
        }

		public short Nationality {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
					Version.GetType () == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0xB8;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0xC0;
				else
					return 0x0;
			}
		}

		public short PersonAttributes {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
					Version.GetType () == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0xBC;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0xC4;
				else
					return 0x0;
			}
		}

		public short Contract {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
					Version.GetType () == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0xE4;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0xEC;
				else
					return 0x0;
			}
		}

		public short Club {
			get {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0x13C;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x144;
				else
					return 0x0;
			}
		}

		public short JobAttributes {
			get {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0x144;
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                    return 0x14C;
				else
					return 0x0;
			}
		}
	}
}

