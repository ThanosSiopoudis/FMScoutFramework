using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FMScoutFramework.Core.Entities.GameVersions
{
	public interface IPersonVersionOffsets
	{
		int Player { get; }
		int Staff { get; }
		int HumanManager { get; }
		int PlayerStaff { get; }
		int Official { get; }
	}
}
