using System;
using System.Linq;
using System.Diagnostics;
using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Managers;

namespace FMScoutFramework.Core.Entities.GameVersions
{

    internal class Steam_15_2_1_Windows : IIVersion
    {
        public IVersionMemoryAddresses MemoryAddresses { get; private set; }
        public IVersionPersonEnumPointers PersonEnum { get; private set; }
        public IPersonVersionOffsets PersonOffsets { get; private set; }

        public Steam_15_2_1_Windows()
        {
            MemoryAddresses = new VersionMemoryAddresses();
            PersonEnum = new VersionPersonEnumPointers();
            PersonOffsets = new PersonVersionOffsets();
        }

        public OperatingSystemEnum OperatingSystem
        {
            get
            {
                return OperatingSystemEnum.Windows;
            }
        }

        public string Description
        {
            get { return "15.2.1 Steam"; }
        }

        public string MainVersionNumber
        {
            get { return "15"; }
        }

        public bool SupportsProcess(FMProcess process, byte[] context)
        {
#if LINUX || MAC
			return false;
#endif

#if WINDOWS
            if (process.VersionDescription != "15.2.1f585343") return false;

            var dt = ProcessManager.ReadDateTime(process.BaseAddress + MemoryAddresses.CurrentDateTime);
            if (dt.Year < 2012 || dt.Year > 2150)
                return false;

            return true;
#endif
        }

        public class VersionMemoryAddresses : IVersionMemoryAddresses
        {
            public int MainAddress { get { return 0x1543094; } }
            public int MainOffset { get { return 0x0; } }
            public int XorDistance { get { return 0x40; } } // Not XOR but useful
			public int StringOffset { get { return 0x4; } }

            public byte[] versionSig
            {
                get
                {
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

            [MemoryAddress(CountLength = 4, BytesToSkip = 0x10)]
            public int City { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x14)]
            public int Club { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x1C)]
            public int Continent { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x38)]
            public int Nation { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x0)]
            public int League { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x4C)]
            public int Stadium { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x58)]
            public int Team { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x3C)]
            public int Person { get { return 0x0; } }

            public int CurrentDateTime { get { return 0x267ED1E; } }
        }

        public class VersionPersonEnumPointers : IVersionPersonEnumPointers
        {
            public int Player { get { return 0x26FE180; } }
            public int Staff { get { return 0x26FC2F4; } }
            public int PlayerStaff { get { return 0x2703958; } }
            public int HumanManager { get { return 0x26F45E8; } }
            public int Official { get { return 0x26FF640; } }
            // RETIRED PERSON: 0x26FF640
            // NON PLAYER: 0x26FAEBC

        }

        /// <summary>
        /// How many bytes the pointer should be corrected for persons.
        /// </summary>
        public class PersonVersionOffsets : IPersonVersionOffsets
        {
			public int Person { get { return -0xC4; } }
            public int Player { get { return -0x21C; } }
            public int Staff { get { return -0x84; } }
            public int HumanManager { get { return -0x44; } }
            public int PlayerStaff { get { return -0x2A0; } }
            public int Official { get { return 0xA4; } }
        }
    }
}

