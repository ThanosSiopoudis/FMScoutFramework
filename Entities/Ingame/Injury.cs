using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Entities.InGame.Interfaces;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Injury : BaseObject, IInjury
    {
		public Injury (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{	}
		public Injury (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{	}

		public Int32 RowID {
			get {
				return PropertyInvoker.Get<Int32>(InjuryOffsets.RowID, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public Int32 ID {
			get {
				return PropertyInvoker.Get<Int32>(InjuryOffsets.ID, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public string SentenceName {
			get {
				return PropertyInvoker.GetString (InjuryOffsets.SentenceName, -1, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public string Name {
			get {
				return PropertyInvoker.GetString (InjuryOffsets.Name, -1, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}
	}
}

