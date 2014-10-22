using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class PersonAttributes : BaseObject
	{
		public PersonAttributes (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{	}
		public PersonAttributes (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{	}

		public byte Adaptability {
			get {
				return PropertyInvoker.Get<byte> (PersonAttributeOffsets.Adaptability, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Ambition {
			get {
				return PropertyInvoker.Get<byte> (PersonAttributeOffsets.Ambition, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Loyalty {
			get {
				return PropertyInvoker.Get<byte> (PersonAttributeOffsets.Loyalty, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Pressure {
			get {
				return PropertyInvoker.Get<byte>(PersonAttributeOffsets.Pressure, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Professionalism {
			get {
				return PropertyInvoker.Get<byte> (PersonAttributeOffsets.Professionalism, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Sportsmanship {
			get {
				return PropertyInvoker.Get<byte>(PersonAttributeOffsets.Sportsmanship, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Temperament {
			get {
				return PropertyInvoker.Get<byte> (PersonAttributeOffsets.Temperament, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Controversy {
			get {
				return PropertyInvoker.Get<byte> (PersonAttributeOffsets.Controversy, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}
	}
}

