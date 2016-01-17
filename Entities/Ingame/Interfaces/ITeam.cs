namespace FMScoutFramework.Core.Entities.InGame.Interfaces
{
    public interface ITeam
    {
        int ID { get; }
        ushort Reputation { get; }
        TeamType TeamType { get; }
    }
}