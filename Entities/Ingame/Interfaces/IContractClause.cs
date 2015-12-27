namespace FMScoutFramework.Core.Entities.InGame.Interfaces
{
    public interface IContractClause
    {
        byte Info { get; }
        ClauseType Type { get; }
        int Value { get; }
    }
}