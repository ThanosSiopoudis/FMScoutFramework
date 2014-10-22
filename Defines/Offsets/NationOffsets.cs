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

        public short Name
        {
            get
            {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
					Version.GetType() == typeof(Steam_14_3_1_Linux))
                {
                    return 0x54;
                }
                else
                {
                    return 0x68;
                }
            }
        }
	}
}

