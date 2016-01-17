using System;
using System.Globalization;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Entities.InGame.Interfaces;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class ContractClause : BaseObject, IContractClause
    {
		public ContractClause (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{	}
		public ContractClause (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{	}

		public Int32 Value {
			get {
				return PropertyInvoker.Get<Int32> (ContractClausesOffsets.Value, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public ClauseType Type {
			get {
				return (ClauseType)PropertyInvoker.Get<byte> (ContractClausesOffsets.Type, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Info {
			get {
				return PropertyInvoker.Get<byte> (ContractClausesOffsets.Info, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public override string ToString ()
		{
			string result = "";
			switch (this.Type) {
			case ClauseType.YearlyWageRise:
			case ClauseType.PromotionWageIncrease:
			case ClauseType.RelegationWageDecrease:
			case ClauseType.SellOnFeeProfit:
			case ClauseType.TopDivisionPromotionWageRise:
			case ClauseType.TopDivisionRelegationWageDrop:
				result = string.Format ("{0}%", this.Value);
				break;
			case ClauseType.SellOnFee:
				result = string.Format ("{0}%", this.Info);
				break;
			case ClauseType.OneYearExtensionAfterLeagueGamesFinalSeason:
				result = string.Format ("{0} Games", this.Info);
				break;
			case ClauseType.SeasonalLandmarkGoalBonus:
				result = string.Format("{0} ({1})", this.Info, this.Value.ToString("C0", CultureInfo.CreateSpecificCulture("en-GB")));
				break;
			case ClauseType.WageAfterReachingInternationalCaps:
			case ClauseType.WageAfterReachingClubCareerLeagueGames:
				result = string.Format ("{0}/pw {1}", this.Value.ToString ("C0", CultureInfo.CreateSpecificCulture ("en-GB")), this.Info);
				break;
			case ClauseType.OptionalContractExtensionByClub:
				result = string.Format ("{0} Year(s)", this.Info);
				break;
			default:
				result = this.Value.ToString ("C0", CultureInfo.CreateSpecificCulture ("en-GB"));
				break;
			}

			return result;
		}
	}

	public enum ClauseType {
		MinimumFeeRelease = 0,
		RelegationFeeRelease = 1,
		NonPromotionRelease = 2,
		YearlyWageRise = 3,
		PromotionWageIncrease = 4,
		RelegationWageDecrease = 5,
		StaffJobRelease = 6,
		UnknownType7 = 7,
		SellOnFee = 8,
		SellOnFeeProfit = 9,
		SeasonalLandmarkGoalBonus = 10,
		OneYearExtensionAfterLeagueGamesFinalSeason = 11,
		MatchHighestEarner = 12,
		WageAfterReachingClubCareerLeagueGames = 13,
		TopDivisionPromotionWageRise = 14,
		TopDivisionRelegationWageDrop = 15,
		MinimumFeeReleaseToForeignClubs = 16,
		MinimumFeeReleaseToHigherDivisionClubs = 17,
		MinimumFeeReleaseToDomesticClubs = 18,
		WageAfterReachingInternationalCaps = 19,
		UnknownType20 = 20,
		UnknownType21 = 21,
		OptionalContractExtensionByClub = 22
	}
}

