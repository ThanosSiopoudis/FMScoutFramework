using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Offsets
{
	public sealed class ClubFinancesOffsets
	{
        public IVersion Version;

        public ClubFinancesOffsets(IVersion version)
        {
            this.Version = version;
        }

		public const short Balance = 0xC;
        public const short AverageTicketPrice = 0x10;
        public const short AverageSeasonTicketPrice = 0x14;
        public const short EmbargoStartDate = 0x24;
        public const short EmbargoEndDate = 0x28;
        public const short EmbargoAppealDate = 0x2C;
        public const short SugarDaddy = 0x31;
		public const short RemainingBudget = 0x3C;
		public const short SeasonTransferFunds = 0x40;
		public const short TransferIncomePercentage = 0x44;
		public const short YouthGrantIncome = 0x4C;
		public const short WeeklyWageBudget = 0x70;
        public const short HighestWage = 0x74;
        public const short WeeklyWageBudgetUsed = 0x78;
		public const short HighestWagePaid = 0x84;

        public short LatestSeasonTicketSales
        {
            get
            {
                if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_1_Windows) ||
                    Version.GetType() == typeof(Steam_14_3_1_Mac))
                {
                    return 0xAC;
                }
                else if (Version.GetType() == typeof(Steam_15_2_1_Windows))
                {
                    return 0xB0;
                }

                return 0x0;
            }
        }
	}
}

