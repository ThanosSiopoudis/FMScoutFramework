using System;
using System.Linq;
using System.Diagnostics;
using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Managers;

namespace FMScoutFramework.Core.Entities.GameVersions
{

	internal class Steam_14_3_0_Windows : IIVersion
	{
		public IVersionMemoryAddresses MemoryAddresses { get; private set; }
		public IVersionPersonEnumPointers PersonEnum { get; private set; }
		public IPersonVersionOffsets PersonOffsets { get; private set; }

		public Steam_14_3_0_Windows ()
		{
			MemoryAddresses = new VersionMemoryAddresses ();
			PersonEnum = new VersionPersonEnumPointers();
			PersonOffsets = new PersonVersionOffsets();
		}

		public string Description {
			get { return "14.3.0 Steam"; }
		}

        public string MainVersionNumber
        {
            get { return "14"; }
        }

		public bool SupportsProcess(FMProcess process, byte[] context)
		{
			#if LINUX || MAC
			return false;
			#endif

			#if WINDOWS
            if (process.VersionDescription != "14.3.0f474125") return false;

            var dt = ProcessManager.ReadDateTime(process.BaseAddress + MemoryAddresses.CurrentDateTime);
            if (dt.Year < 2012 || dt.Year > 2150)
                return false;

			return true;
			#endif
		}

		public class VersionMemoryAddresses : IVersionMemoryAddresses
		{
			public int MainAddress { get { return 0x1988D94; } }
			public int MainOffset { get { return 0x1C; } }
			public int XorDistance { get { return 0x54; } }
			public int StringOffset { get { return 0xC; } }

			public byte[] versionSig { 
				get { 
					return new byte[] {
						0x31, 0x00, 0x34, 0x00,
						0x2E, 0x00,	0x33, 0x00,
						0x2E, 0x00,	0x30, 0x00,
						0x20, 0x00,	0x34, 0x00,
						0x37, 0x00,	0x34, 0x00,
						0x31, 0x00,	0x32, 0x00,
						0x37, 0x00,	0x20, 0x00,
						0x28, 0x00,	0x6D, 0x00,
						0x2E, 0x00,	0x65, 0x00,
						0x20, 0x00,	0x76, 0x00,
						0x31, 0x00,	0x34, 0x00, 
						0x35, 0x00,	0x34, 0x00,
						0x29, 0x00
					};
				}
			}

			[MemoryAddress(CountLength = 4, BytesToSkip = 0x14)]
            public int City { get { return 0x1988D94; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x1C)]
            public int Club { get { return 0x1988D94; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x2C)]
            public int Continent { get { return 0x1988D94; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x64)]
            public int Nation { get { return 0x1988D94; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x24)]
            public int League { get { return 0x1988D94; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x8C)]
            public int Stadium { get { return 0x1988D94; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0xA4)]
            public int Team { get { return 0x1988D94; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x6C)]
            public int Person { get { return 0x1988D94; } }

			public int CurrentDateTime { get { return 0x24C8E6C; } }
		}

		public class VersionPersonEnumPointers : IVersionPersonEnumPointers
		{
			public int Player { get { return 0x347D104; } }
			public int Staff { get { return 0x347EB6C; } }
			public int PlayerStaff { get { return 0x3473ED4; } }
			public int HumanManager { get { return 0x347608C; } }
			public int Official { get { return 0x9EA1658; } } // Not Fixed
			// RETIRED PERSON: 0x9EA61E8
		}

		/// <summary>
		/// How many bytes the pointer should be corrected for persons.
		/// Complies with 'AddressUsedInGame' in FMRTE
		/// </summary>
		public class PersonVersionOffsets : IPersonVersionOffsets
		{
			public int Person { get { return -0xC4; } }
			public int Player { get { return -0x150; } } // OK
			public int Staff { get { return -0x44; } }
			public int HumanManager { get { return -0x44; } }
			public int PlayerStaff { get { return -0x15c; } }
			public int Official { get { return 0x0; } }
		}
	}
}

