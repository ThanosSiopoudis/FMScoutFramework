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

		public short RowID {
			get {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0x148;
				else
					return 0x0;
			}
		}

		public short ID {
			get {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0x14C;
				else
					return 0x0;
			}
		}

		public short DateOfBirth {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
					Version.GetType () == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0xC;
				else
					return 0x0;
			}
		}

		public short Fullname {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
					Version.GetType () == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0x10;
				else
					return 0x0;
			}
		}

		public short FirstName {
			get {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0x18;
				else
					return 0x0;
			}
		}

		public short LastName {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
					Version.GetType () == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0x1C;
				else
					return 0x0;
			}
		}

		public short Nationality {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
					Version.GetType () == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0x28;
				else
					return 0x0;
			}
		}

		public short PersonAttributes {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
					Version.GetType () == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0x2C;
				else
					return 0x0;
			}
		}

		public short Contract {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
					Version.GetType () == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0x54;
				else
					return 0x0;
			}
		}

		public short Club {
			get {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0xAC;
				else
					return 0x0;
			}
		}

		public short Jobs {
			get {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0xB4;
				else
					return 0x0;
			}
		}

		public short StaffAttributes {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
					Version.GetType () == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0xCC;
				else
					return 0x0;
			}
		}

		public short HomeReputation {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
					Version.GetType () == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0x130;
				else
					return 0x0;
			}
		}

		public short CurrentReputation {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
					Version.GetType () == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0x132;
				else
					return 0x0;
			}
		}

		public short WorldReputation {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
					Version.GetType () == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0x134;
				else
					return 0x0;
			}
		}

		public short CurrentAbility {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
					Version.GetType () == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0x136;
				else
					return 0x0;
			}
		}

		public short PotentialAbility {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
					Version.GetType () == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
					return 0x138;
				else
					return 0x0;
			}
		}
	}
}

