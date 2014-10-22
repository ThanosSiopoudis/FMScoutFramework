using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Continent : BaseObject
	{
		public Continent (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{	}
		public Continent (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{	}
	}
}

