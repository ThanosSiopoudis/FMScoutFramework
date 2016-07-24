using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Offsets
{
	public sealed class NationOffsets
	{
        public IVersion Version;

        public NationOffsets(IVersion version)
        {
            this.Version = version;
        }

		public const short RowID		= 0x4;
		public const short ID			= 0x8;
        public const short Teams        = 0x10;
        public const short RivalNations = 0x28;

        public short Name
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux) ||
					Version.GetType() == typeof(Steam_15_3_2_Windows) ||
                    Version.GetType() == typeof(Steam_15_3_2_Mac) ||
                    Version.GetType() == typeof(Steam_16_2_0_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_0_Windows) || 
                    Version.GetType() == typeof(Steam_16_3_1_Windows) ||
                    Version.GetType() == typeof(Steam_16_3_2_Windows))
                {
                    return 0x54;
                }
                else
                {
                    return 0x68;
                }
            }
        }

        public const short ShortName = 0x58;
        public const short ThreeLetterName = 0x60;
        public const short Nationality = 0x64;
        public const short SpokenLanguages = 0x6C;
        public const short UnknownList1 = 0x74;     // Points to list of UIDs
        public const short TaxRules = 0x78;
        public const short UnknownArray1 = 0x84;    // Array of Nations
        public const short NationTransferPreferences = 0x90;
        public const short ContinentTransferPreferences = 0x9C;
        public const short RegionTransferPreferences = 0xA8;
        public const short Capital = 0xD8;
        public const short Continent = 0xDC;
        public const short Region = 0xE0;
        public const short Currency = 0xE4;
        public const short FIFAPosition = 0x15C;
        public const short FIFARankingPoints = 0x15E;
        public const short UnknownArray2 = 0x198;   // Array of pointers to Int16 + Date (with time)
        public const short EUROCoefficients = 0x1BC;
        public const short UnknownFloat1 = 0x208;
        public const short UnknownFloat2 = 0x20C;
        public const short UnknownArray3 = 0x234;   // Unknown Shortlist
        public const short MainSquadGKShortlist = 0x278;
        public const short MainSquadDefShortlist = 0x284;
        public const short MainSquadMidShortlist = 0x290;
        public const short MainSquadFWShortlist = 0x29C;
        public const short U21GKShortlist = 0x2A8;
        public const short U21DefShortlist = 0x2B4;
        public const short U21MidShortlist = 0x2C0;
        public const short U21FWShortlist = 0x2CC;
        public const short U19GKShortlist = 0x2D8;
        public const short U19DefShortlist = 0x2E4;
        public const short U19MidShortlist = 0x2F0;
        public const short U19FWShortlist = 0x2FC;
        // A lot of unknown shortlist from here on. Can someone help?
	}
}

