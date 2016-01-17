namespace FMScoutFramework.Core.Entities.InGame.Interfaces
{
    public interface IClubFinances
    {
        int Balance { get; }
        int HighestWagePaid { get; }
        int LastestSeasonTickets { get; }
        int LatestSeasonTicketsAddress { get; }
        int RemainingBudget { get; }
        int SeasonTransferFunds { get; }
        int TransferIncomePercentage { get; }
        int WeeklyWageBudget { get; }
        int YouthGrantIncome { get; }
    }
}