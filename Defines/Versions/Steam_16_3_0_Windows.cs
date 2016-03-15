using System;
using System.Linq;
using System.Diagnostics;
using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Managers;

namespace FMScoutFramework.Core.Entities.GameVersions
{

    internal class Steam_16_3_0_Windows : IIVersion
    {
        public IVersionMemoryAddresses MemoryAddresses { get; private set; }
        public IVersionPersonEnumPointers PersonEnum { get; private set; }
        public IPersonVersionOffsets PersonOffsets { get; private set; }

        public Steam_16_3_0_Windows()
        {
            MemoryAddresses = new VersionMemoryAddresses();
            PersonEnum = new VersionPersonEnumPointers();
            PersonOffsets = new PersonVersionOffsets();
        }

        public string Description
        {
            get { return "16.3.0 Steam"; }
        }

        public string MainVersionNumber
        {
            get { return "16"; }
        }

        public bool SupportsProcess(FMProcess process, byte[] context)
        {
#if LINUX || MAC
			return false;
#endif

#if WINDOWS
            if (process.VersionDescription != "16.3.0f776772") return false;

            var dt = ProcessManager.ReadDateTime(process.BaseAddress + MemoryAddresses.CurrentDateTime);
            if (dt.Year < 2012 || dt.Year > 2150)
                return false;

            return true;
#endif
        }

        public class VersionMemoryAddresses : IVersionMemoryAddresses
        {
            public int MainAddress { get { return 0x25706C8; } }
            public int MainOffset { get { return 0x0; } }
            public int XorDistance { get { return 0x48; } } // Not XOR but useful
            public int StringOffset { get { return 0x0; } }

            public byte[] versionSig
            {
                get
                {
                    return new byte[] {
                        0x31, 0x00, 0x34, 0x00,
                        0x2E, 0x00, 0x33, 0x00,
                        0x2E, 0x00, 0x30, 0x00,
                        0x20, 0x00, 0x34, 0x00,
                        0x37, 0x00, 0x34, 0x00,
                        0x31, 0x00, 0x32, 0x00,
                        0x37, 0x00, 0x20, 0x00,
                        0x28, 0x00, 0x6D, 0x00,
                        0x2E, 0x00, 0x65, 0x00,
                        0x20, 0x00, 0x76, 0x00,
                        0x31, 0x00, 0x34, 0x00,
                        0x35, 0x00, 0x34, 0x00,
                        0x29, 0x00
                    };
                }
            }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0xC)]
            public int Award { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x10)]
            public int City { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x14)]
            public int Club { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x18)]
            public int League { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x1C)]
            public int Continent { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x20)]
            public int Currency { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x24)]
            public int Unknown1 { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x28)]
            public int Injury { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x2C)]
            public int MediaSource { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x30)]
            public int Language { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x34)]
            public int LocalRegion { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x38)]
            public int Nation { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x3C)]
            public int Person { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x40)]
            public int Unknown2 { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x44)]
            public int Unknown3 { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x48)]
            public int Sponsors { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x4C)]
            public int Stadium { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x50)]
            public int Unknown4 { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x54)]
            public int Unknown5 { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x58)]
            public int Team { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x5C)]
            public int Weather { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x60)]
            public int Unknown6 { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x64)]
            public int Derby { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x68)]
            public int Agreement { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x6C)]
            public int Firstname { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x70)]
            public int Lastname { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x74)]
            public int Commonname { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x78)]
            public int Unknown7 { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x7C)]
            public int Unknown8 { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x80)]
            public int Unknown9 { get { return 0x0; } }

            public int CurrentDateTime { get { return 0x255BCDA; } }
        }

        public class VersionPersonEnumPointers : IVersionPersonEnumPointers
        {
            public int Player { get { return 0x277F19C; } } // Done
            public int Staff { get { return 0x277D734; } } // Done
            public int NonPlayer { get { return 0x2263EBC; } }
            public int PlayerStaff { get  { return 0x2785E00; } } // Done
            public int HumanManager { get { return 0x2775720; } } // Done
            public int Official { get { return 0x2267C40; } }
            public int RetiredPerson { get { return 0x2263B00; } }
            public int Journalist { get { return 0x226A7C4; } }
        }

        /// <summary>
        /// How many bytes the pointer should be corrected for persons.
        /// </summary>
        public class PersonVersionOffsets : IPersonVersionOffsets
        {
            public int Person { get { return -0xC4; } }
            public int Player { get { return -0x208; } }
            public int Staff { get { return -0x84; } }
            public int NonPlayer { get { return 0x0; } }
            public int HumanManager { get { return -0x44; } }
            public int PlayerStaff { get { return -0x28C; } }
            public int Official { get { return -0xA4; } }
            public int Retired { get { return 0x0; } }
            public int Journalist { get { return -0x4C; } }
        }
    }
}