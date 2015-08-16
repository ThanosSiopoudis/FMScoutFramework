using System;
using FMScoutFramework.Core.Attributes;

namespace FMScoutFramework.Core.Entities.GameVersions
{
	public interface IVersionMemoryAddresses
	{
		int MainAddress { get; }
		int MainOffset { get; }
		int XorDistance { get; }
		int StringOffset { get; }
		byte[] versionSig { get; }

		[MemoryAddress(CountLength = 4, BytesToSkip = 0x28)]
		int City { get; }

		[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x28)]
		int Club { get; }

		[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x28)]
		int Continent { get; }

		[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x28)]
		int Nation { get; }

		[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x28)]
		int League { get; }

		/*
		[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x28)]
		int Language { get; } */

		[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x28)]
		int Stadium { get; }

		[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x28)]
		int Team { get; }

		[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x28)]
		int Person { get; }

		int CurrentDateTime { get; }

		/*
		[MemoryAddressAttribute(CountLength = 4, BytesToSkip = 0x28)]
		int ActiveObject { get; } */
	}
}

