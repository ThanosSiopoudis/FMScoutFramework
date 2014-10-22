using System;
using System.Globalization;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class ContractBonus : BaseObject
	{
		public ContractBonus (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{	}
		public ContractBonus (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{	}

		public BonusType Type {
			get {
				return (BonusType)PropertyInvoker.Get<byte> (ContractBonusOffsets.Type, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public Int32 Value {
			get {
				return PropertyInvoker.Get<Int32> (ContractBonusOffsets.Value, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public override string ToString ()
		{
			return this.Value.ToString("C0", CultureInfo.CreateSpecificCulture("en-GB"));
		}
	}

	public enum BonusType {
		AppearanceFee = 0,
		GoalFee = 1,
		CleanSheetFee = 2,
		TeamOfTheYear = 3,
		TopGoalscorer = 4,
		PromotionFee = 5,
		AvoidRelegationFee = 6,
		InternationalCapFee = 7,
		UnusedSubstitutionFee = 8
	}
}

