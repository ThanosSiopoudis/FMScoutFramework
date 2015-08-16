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

		public short DateOfBirth
		{
			get
			{
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux) ||
					Version.GetType() == typeof(Steam_15_3_2_Mac) ||
					Version.GetType() == typeof(Steam_15_3_2_Windows))
					return 0xC;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
					return 0x160;
				else
					return 0x178;
			}
		}

		public short Fullname
		{
			get
			{
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux) ||
					Version.GetType() == typeof(Steam_15_3_2_Mac) ||
					Version.GetType() == typeof(Steam_15_3_2_Windows))
					return 0x10;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
					return 0x164;
				else
					return 0x17C;
			}
		}

		public short Firstname
		{
			get
			{
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux) ||
					Version.GetType() == typeof(Steam_15_3_2_Mac) ||
					Version.GetType() == typeof(Steam_15_3_2_Windows))
					return 0x18;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
					return 0x16C;
				else
					return 0x184;
			}
		}

		public short Lastname
		{
			get
			{
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux) ||
					Version.GetType() == typeof(Steam_15_3_2_Mac) ||
					Version.GetType() == typeof(Steam_15_3_2_Windows))
					return 0x1C;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
					return 0x170;
				else
					return 0x188;
			}
		}

		public short Nickname
		{
			get
			{
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux) ||
					Version.GetType() == typeof(Steam_15_3_2_Mac) ||
					Version.GetType() == typeof(Steam_15_3_2_Windows))
					return 0x20;
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
					Version.GetType() == typeof(Steam_14_3_1_Linux) ||
					Version.GetType() == typeof(Steam_15_3_2_Mac) ||
					Version.GetType() == typeof(Steam_15_3_2_Windows))
					return 0x24;
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
					Version.GetType() == typeof(Steam_14_3_1_Linux) ||
					Version.GetType() == typeof(Steam_15_3_2_Mac) ||
					Version.GetType() == typeof(Steam_15_3_2_Windows))
					return 0x28;
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
					Version.GetType() == typeof(Steam_14_3_1_Linux) ||
					Version.GetType() == typeof(Steam_15_3_2_Mac) ||
					Version.GetType() == typeof(Steam_15_3_2_Windows))
					return 0x2C;
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
					Version.GetType() == typeof(Steam_14_3_1_Linux) ||
					Version.GetType() == typeof(Steam_15_3_2_Mac) ||
					Version.GetType() == typeof(Steam_15_3_2_Windows))
					return 0x54;
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
					Version.GetType() == typeof(Steam_14_3_1_Linux) ||
					Version.GetType() == typeof(Steam_15_3_2_Mac) ||
					Version.GetType() == typeof(Steam_15_3_2_Windows))
					return 0xBC;
				else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
					return 0x200;
				else
					return 0x22C;
			}
		}
	}
}
