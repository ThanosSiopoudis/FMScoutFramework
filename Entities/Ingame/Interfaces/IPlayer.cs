namespace FMScoutFramework.Core.Entities.InGame.Interfaces
{
    public interface IPlayer
    {
        int AskingPrice { get; }
        int BansAddress { get; }
        ushort CA { get; }
        short Condition { get; }
        short CurrentReputation { get; }
        short Fitness { get; }
        double GrowthPotential { get; }
        ushort Height { get; }
        short HomeReputation { get; }
        int ID { get; }
        Injury[] Injuries { get; }
        int InjuriesAddress { get; }
        byte InternationalApps { get; }
        byte InternationalGoals { get; }
        bool isBanned { get; }
        bool isInjured { get; }
        short Jadedness { get; }
        ushort PA { get; }
        PlayerStats PlayerStats { get; }
        int RowID { get; }
        Team Team { get; }
        byte U21InternationalApps { get; }
        byte U21InternationalGoals { get; }
        int Value { get; }
        ushort Weight { get; }
        short WorldReputation { get; }
    }
}