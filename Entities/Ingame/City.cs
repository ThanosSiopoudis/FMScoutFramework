using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class City : BaseObject
	{
		public City (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{	}
		public City (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{	}
	}
}

