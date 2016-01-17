namespace FMScoutFramework.Core.Entities.InGame.Interfaces
{
    public interface IClub
    {
        Nation BasedNation { get; }
        ClubFinances ClubFinances { get; }
        int ClubFinancesAddress { get; }
        int ID { get; }
        string Name { get; }
        Nation Nation { get; }
        string ShortName { get; }
        Team[] Teams { get; }
    }
}