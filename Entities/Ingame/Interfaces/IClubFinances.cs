namespace FMScoutFramework.Core.Entities.InGame.Interfaces
{
    public interface IClubFinances
    {
        int Balance { get; set; }
        int HighestWagePaid { get; set; }
        int LastestSeasonTickets { get; set; }
        int LatestSeasonTicketsAddress { get; set; }
        int RemainingBudget { get; set; }
        int SeasonTransferFunds { get; set; }
        int TransferIncomePercentage { get; set; }
        int WeeklyWageBudget { get; set; }
        int HighestWage { get; set; }
        int YouthGrantIncome { get; set; }
    }
}