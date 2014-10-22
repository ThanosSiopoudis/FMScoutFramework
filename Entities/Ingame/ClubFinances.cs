using System;
using System.Collections.Generic;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Utilities;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class ClubFinances : BaseObject
	{
		public ClubFinances (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{	}
		public ClubFinances (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{	}

		public int Balance {
			get {
				if (Version.GetType() == typeof(Steam_14_3_0_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_1_Windows))
                {
					try{
						int rotateAmount = ((MemoryAddress + ClubFinancesOffsets.Balance) & 31);
						UInt32 encryptedBalance = (UInt32)ProcessManager.ReadUInt32 (MemoryAddress + ClubFinancesOffsets.Balance);
						encryptedBalance = BitwiseOperations.rol (encryptedBalance, rotateAmount);
						encryptedBalance = (encryptedBalance ^ 0x513130E);
						encryptedBalance = BitwiseOperations.rol (encryptedBalance, 9);
						encryptedBalance = ~encryptedBalance;

						return (int)encryptedBalance;
					}
					catch {
						return 0;
					}
				} else {
					return 0;
				}
			}
		}

		public int RemainingBudget {
			get {
				return PropertyInvoker.Get<Int32> (ClubFinancesOffsets.RemainingBudget, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public int SeasonTransferFunds {
			get {
				return PropertyInvoker.Get<Int32> (ClubFinancesOffsets.SeasonTransferFunds, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public int TransferIncomePercentage {
			get {
				return PropertyInvoker.Get<Int32> (ClubFinancesOffsets.TransferIncomePercentage, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public int YouthGrantIncome {
			get {
				return PropertyInvoker.Get<Int32> (ClubFinancesOffsets.YouthGrantIncome, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public int WeeklyWageBudget {
			get {
				return PropertyInvoker.Get<Int32> (ClubFinancesOffsets.WeeklyWageBudget, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public int HighestWagePaid {
			get {
				return PropertyInvoker.Get<Int32> (ClubFinancesOffsets.HighestWagePaid, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public int LatestSeasonTicketsAddress {
			get {
				return PropertyInvoker.Get<Int32> (ClubFinancesOffsets.LatestSeasonTicketSales, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public int LastestSeasonTickets {
			get {
				return PropertyInvoker.Get<Int32> (0x0, OriginalBytes, this.LatestSeasonTicketsAddress, DatabaseMode);
			}
		}
	}
}