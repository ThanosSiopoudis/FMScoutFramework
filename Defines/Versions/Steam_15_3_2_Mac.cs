using System;
using System.Linq;
using System.Diagnostics;
using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Managers;

namespace FMScoutFramework.Core.Entities.GameVersions
{

	internal class Steam_15_3_2_Mac : IIVersion
	{
		public IVersionMemoryAddresses MemoryAddresses { get; private set; }
		public IVersionPersonEnumPointers PersonEnum { get; private set; }
		public IPersonVersionOffsets PersonOffsets { get; private set; }

		public Steam_15_3_2_Mac ()
		{
			MemoryAddresses = new VersionMemoryAddresses ();
			PersonEnum = new VersionPersonEnumPointers();
			PersonOffsets = new PersonVersionOffsets();
		}

        public OperatingSystemEnum OperatingSystem
        {
            get
            {
                return OperatingSystemEnum.Mac;
            }
        }

        public string Description {
			get { return "15.3.2 Steam"; }
		}

		public string MainVersionNumber
		{
			get { return "15"; }
		}

		public bool SupportsProcess(FMProcess process, byte[] context)
		{
			#if LINUX || WINDOWS
			return false;
			#endif
			#if MAC
			// Attempt to read the number of continents.
			// They MUST be 7
			// Then double check the date!
			int numberOfObjects = GameManager.TryGetPointerObjects(MemoryAddresses.MainAddress, MemoryAddresses.Continent, ProcessManager.fmProcess, "15");
			if (numberOfObjects != 7)
				return false;

			DateTime dt = ProcessManager.ReadDateTime (MemoryAddresses.CurrentDateTime);
			if (dt.Year < 2012 || dt.Year > 2150)
				return false;

			process.VersionDescription = "15.3.2 627044 (m.e v1555)";
			return true;
			#endif
		}

		public class VersionMemoryAddresses : IVersionMemoryAddresses
		{
			public int MainAddress { get { return 0x2D28944; } }
			public int MainOffset { get { return 0x0; } }
			public int XorDistance { get { return 0x40; } }
			public int StringOffset { get { return 0x0; } }

			public byte[] versionSig { 
				get { 
					return new byte[] {
						0x31, 0x00, 0x34, 0x00,
						0x2E, 0x00,	0x33, 0x00,
						0x2E, 0x00,	0x30, 0x00,
						0x20, 0x00,	0x34, 0x00,
						0x37, 0x00,	0x34, 0x00,
						0x31, 0x00,	0x32, 0x00,
						0x39, 0x00,	0x20, 0x00,
						0x28, 0x00,	0x6D, 0x00,
						0x2E, 0x00,	0x65, 0x00,
						0x20, 0x00,	0x76, 0x00,
						0x31, 0x00,	0x34, 0x00, 
						0x35, 0x00,	0x34, 0x00,
						0x29, 0x00
					};
				}
			}

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0xC)]
			public int Award { get { return 0xC; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x10)]
			public int City { get { return 0x10; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x14)]
			public int Club { get { return 0x14; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x18)]
			public int League { get { return 0x18; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x1C)]
			public int Continent { get { return 0x1C; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x20)]
			public int Currency { get { return 0x20; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x24)]
			public int Unknown1 { get { return 0x24; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x28)]
			public int Injury { get { return 0x28; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x2C)]
			public int MediaSource { get { return 0x2C; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x30)]
			public int Language { get { return 0x30; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x34)]
			public int LocalRegion { get { return 0x34; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x38)]
			public int Nation { get { return 0x38; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x3C)]
			public int Person { get { return 0x3C; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x40)]
			public int Unknown2 { get { return 0x40; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x44)]
			public int Unknown3 { get { return 0x44; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x48)]
			public int Sponsors { get { return 0x48; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x4C)]
			public int Stadium { get { return 0x4C; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x50)]
			public int Unknown4 { get { return 0x50; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x54)]
			public int Unknown5 { get { return 0x54; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x58)]
			public int Team { get { return 0x58; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x5C)]
			public int Weather { get { return 0x5C; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x60)]
			public int Unknown6 { get { return 0x60; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x64)]
			public int Derby { get { return 0x64; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x68)]
			public int Agreement { get { return 0x68; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x6C)]
			public int Firstname { get { return 0x6C; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x70)]
			public int Lastname { get { return 0x70; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x74)]
			public int Commonname { get { return 0x74; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x78)]
			public int Unknown7 { get { return 0x78; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x7C)]
			public int Unknown8 { get { return 0x7C; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x80)]
			public int Unknown9 { get { return 0x80; } }

			public int CurrentDateTime { get { return 0x2D0FD6C; } }
		}

		public class VersionPersonEnumPointers : IVersionPersonEnumPointers
		{
			public int Player { get { return 0x2C78E9C; } }
			public int Staff { get { return 0x2C74A08; } }
			public int PlayerStaff { get { return 0x2C7BEBC; } }
			public int HumanManager { get { return 0x2C80270; } }
			public int Official { get { return 0x2C8639C; } }
			public int NonPlayer { get { return 0x2C85B68; } }
			public int Retired { get { return 0x2C87798; } }
			public int Spokesperson { get { return 0x2C8D25C; } }
			public int AgentType { get { return 0x2C8A45C; } }
			public int Journalist { get { return 0x2C88C88; } }
		}

		/// <summary>
		/// How many bytes the pointer should be corrected for persons.
		/// Complies with 'AddressUsedInGame' in FMRTE
		/// </summary>
		public class PersonVersionOffsets : IPersonVersionOffsets
		{
			public int Person { get { return -0xC4; } }
			public int Player { get { return -0x208; } } // OK
			public int Staff { get { return -0x84; } }
			public int NonPlayer { get { return 0x0; } }
			public int PlayerStaff { get { return -0x28C; } }
			public int Official { get { return -0xA4; } }
			public int Retired { get { return 0x0; } }
			public int Spokesperson { get { return -0x40; } }
			public int Agent { get { return 0x0; } }
			public int Journalist { get { return -0x4C; } }
			public int HumanManager { get { return 0x0; } }
		}
	}
}