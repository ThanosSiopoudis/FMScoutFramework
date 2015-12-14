using System;
using System.Linq;
using System.Diagnostics;
using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Managers;

namespace FMScoutFramework.Core.Entities.GameVersions
{

	internal class Steam_14_3_1_Mac : IIVersion
	{
		public IVersionMemoryAddresses MemoryAddresses { get; private set; }
		public IVersionPersonEnumPointers PersonEnum { get; private set; }
		public IPersonVersionOffsets PersonOffsets { get; private set; }

		public Steam_14_3_1_Mac ()
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
			get { return "14.3.0 Steam"; }
		}

        public string MainVersionNumber
        {
            get { return "14"; }
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
			int numberOfObjects = GameManager.TryGetPointerObjects(MemoryAddresses.MainAddress, 0x2C, ProcessManager.fmProcess);
			if (numberOfObjects != 7)
				return false;

			DateTime dt = ProcessManager.ReadDateTime (MemoryAddresses.CurrentDateTime);
			if (dt.Year < 2012 || dt.Year > 2150)
				return false;

			process.VersionDescription = "14.3.1 487631 (m.e v1454)";
			return true;
			#endif
		}

		public class VersionMemoryAddresses : IVersionMemoryAddresses
		{
			public int MainAddress { get { return 0x32A8000; } }
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

			[MemoryAddress(CountLength = 4, BytesToSkip = 0x14)]
			public int City { get { return 0x32A8000; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x1C)]
			public int Club { get { return 0x32A8000; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x2C)]
			public int Continent { get { return 0x32A8000; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x64)]
			public int Nation { get { return 0x32A8000; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x24)]
			public int League { get { return 0x32A8000; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x8C)]
			public int Stadium { get { return 0x32A8000; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0xA4)]
			public int Team { get { return 0x32A8000; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x6C)]
			public int Person { get { return 0x32A8000; } }

			public int CurrentDateTime { get { return 0x342F85E; } }
		}

		public class VersionPersonEnumPointers : IVersionPersonEnumPointers
		{
			public int Player { get { return 0x33A1D24; } }
			public int Staff { get { return 0x339ACB4; } }
			public int PlayerStaff { get { return 0x33A0D14; } }
			public int HumanManager { get { return 0x33A7C6C; } }
			public int Official { get { return 0x33ABB08; } }
		}

		/// <summary>
		/// How many bytes the pointer should be corrected for persons.
		/// Complies with 'AddressUsedInGame' in FMRTE
		/// </summary>
		public class PersonVersionOffsets : IPersonVersionOffsets
		{
			public int Person { get { return -0xC4; } }
			public int Player { get { return -0x20C; } } // OK
			public int Staff { get { return -0x44; } }
			public int HumanManager { get { return -0x44; } }
			public int PlayerStaff { get { return -0x15c; } }
			public int Official { get { return 0x0; } }
		}
	}
}

