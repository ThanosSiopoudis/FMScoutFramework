namespace FMScoutFramework.Core.Entities.GameVersions
{
	public interface IVersionPersonEnumPointers
	{
		int Player { get; }
		int Staff { get; }
		int PlayerStaff { get; }
		int HumanManager { get; }
		int Official { get; }
	}
}