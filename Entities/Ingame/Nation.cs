using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Attributes;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Nation : BaseObject
	{
        public NationOffsets NationOffsets;
		public Nation (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{
            this.NationOffsets = new NationOffsets(Version);
        }
		public Nation (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{
            this.NationOffsets = new NationOffsets(Version);
        }

		public Int32 ID {
			get {
				return ProcessManager.ReadInt32 (MemoryAddress + NationOffsets.ID);
			}
		}

		public string Name {
			get {
				return ProcessManager.ReadString (MemoryAddress + NationOffsets.Name, -1);
			}
		}

		public override string ToString ()
		{
			return Name;
		}
	}
}

