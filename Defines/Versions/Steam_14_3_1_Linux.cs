using System;
using System.Linq;
using System.Diagnostics;
using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Managers;

namespace FMScoutFramework.Core.Entities.GameVersions
{

	internal class Steam_14_3_1_Linux : IIVersion
	{
		public IVersionMemoryAddresses MemoryAddresses { get; private set; }
		public IVersionPersonEnumPointers PersonEnum { get; private set; }
		public IPersonVersionOffsets PersonOffsets { get; private set; }

		public Steam_14_3_1_Linux ()
		{
			MemoryAddresses = new VersionMemoryAddresses ();
			PersonEnum = new VersionPersonEnumPointers();
			PersonOffsets = new PersonVersionOffsets();
		}

		public string Description {
			get { return "14.3.1 Steam"; }
		}

		public bool SupportsProcess(FMProcess process, byte[] context)
		{
			#if WINDOWS || MAC
			return false;
			#endif
			#if LINUX
			// Try to read the version number from the Heap
			// Look for the version signature
			int memoryAddress = ProcessManager.ReadInt32 (MemoryAddresses.MainAddress);
			memoryAddress = ProcessManager.ReadInt32(memoryAddress + MemoryAddresses.MainOffset);
			int xorValueOne = ProcessManager.ReadInt32 (memoryAddress + 0x2C + 0x4);
			int xorValueTwo = ProcessManager.ReadInt32 (memoryAddress + 0x2C);
			memoryAddress = xorValueTwo ^ xorValueOne;
			memoryAddress = ProcessManager.ReadInt32 (memoryAddress + MemoryAddresses.XorDistance);

			int numberOfObjects = ProcessManager.ReadArrayLength (memoryAddress);
			if (numberOfObjects != 7)
				return false;

			DateTime dt = ProcessManager.ReadDateTime (ProcessManager.fmProcess.BaseAddress + MemoryAddresses.CurrentDateTime);
			if (dt.Year < 2012 || dt.Year > 2150)
				return false;

			process.VersionDescription = "14.3.1 487634 (m.e v1454)";
			return true;
			#endif
		}

		public class VersionMemoryAddresses : IVersionMemoryAddresses
		{
			public int MainAddress { get { return 0xA9A1AF8; } }
			public int MainOffset { get { return 0x1C; } }
			public int XorDistance { get { return 0x54; } }

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
			public int City { get { return 0xA9A1AF8; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x1C)]
			public int Club { get { return 0xA9A1AF8; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x2C)]
			public int Continent { get { return 0xA9A1AF8; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x64)]
			public int Nation { get { return 0xA9A1AF8; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x24)]
			public int League { get { return 0xA9A1AF8; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x8C)]
			public int Stadium { get { return 0xA9A1AF8; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0xA4)]
			public int Team { get { return 0xA9A1AF8; } }

			[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x6C)]
			public int Person { get { return 0xA9A1AF8; } }

			public int CurrentDateTime { get { return 0x45D8; } }
		}

		public class VersionPersonEnumPointers : IVersionPersonEnumPointers
		{
			public int Player { get { return 0x9E8AE44; } }
			public int Staff { get { return 0x9E85EAC; } }
			public int PlayerStaff { get { return 0x9E901AC; } }
			public int HumanManager { get { return 0x9E9D6CC; } } // Not fixed
			public int Official { get { return 0x9EA2428; } }
			// RETIRED PERSON: 0x9EA6FB8
		}

		/// <summary>
		/// How many bytes the pointer should be corrected for persons.
		/// Complies with 'AddressUsedInGame' in FMRTE
		/// </summary>
		public class PersonVersionOffsets : IPersonVersionOffsets
		{
			public int Player { get { return -0x20C; } } // OK
			public int Staff { get { return -0x144; } } // OK
			public int HumanManager { get { return -0x44; } }
			public int PlayerStaff { get { return -0x15c; } }
			public int Official { get { return 0x0; } }
		}
	}
}

