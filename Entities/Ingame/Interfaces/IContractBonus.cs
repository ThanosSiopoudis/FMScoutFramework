namespace FMScoutFramework.Core.Entities.InGame.Interfaces
{
    public interface IContractBonus
    {
        BonusType Type { get; }
        int Value { get; }
    }
}