using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Entities.InGame.Interfaces;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class PlayerStaff : BaseObject, IPlayerStaff
	{
		public PlayerStaff (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{	}
		public PlayerStaff (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{	}
	}
}

