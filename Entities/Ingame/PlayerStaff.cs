using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class PlayerStaff : BaseObject
	{
		public PlayerStaff (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{	}
		public PlayerStaff (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{	}
	}
}

