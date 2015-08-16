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
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows) ||
					Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows))
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
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows) ||
					Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows))
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
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows) ||
					Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows))
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
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows) ||
					Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows))
                    return 0x74;
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
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows) ||
					Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows))
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
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows) ||
					Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows))
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
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows) ||
					Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows))
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
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows) ||
					Version.GetType () == typeof(Steam_15_3_2_Mac) ||
					Version.GetType () == typeof(Steam_15_3_2_Windows))
                    return 0x8C;
                else
                    return 0x0;
            }
        }

		public short PersonAddress {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
				    Version.GetType () == typeof(Steam_14_3_0_Mac) ||
				    Version.GetType () == typeof(Steam_14_3_1_Linux))
					return 0x90;
				else if (Version.GetType () == typeof(Steam_15_2_1_Windows) ||
				         Version.GetType () == typeof(Steam_15_3_2_Mac) ||
				         Version.GetType () == typeof(Steam_15_3_2_Windows)) {
					return 0x98;
				}
				else {
					return 0x0;
				}
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

