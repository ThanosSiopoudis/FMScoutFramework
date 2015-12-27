using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Entities.InGame.Interfaces;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Contract : BaseObject, IContract
    {
		public Contract (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{	}
		public Contract (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{	}

		public Team Team {
			get {
				return PropertyInvoker.GetPointer<Team> (ContractOffsets.Team, OriginalBytes, MemoryAddress, DatabaseMode, Version);
			}
		}

		public JobType JobType {
			get {
				return (JobType)(PropertyInvoker.Get<byte>(ContractOffsets.JobType, OriginalBytes, MemoryAddress, DatabaseMode));
			}
		}

		public Int32 Wage {
			get {
				return PropertyInvoker.Get<Int32> (ContractOffsets.Wage, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public DateTime DateStarted {
			get {
				return PropertyInvoker.Get<DateTime> (ContractOffsets.DateStarted, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public DateTime DateExpires {
			get {
				return PropertyInvoker.Get<DateTime> (ContractOffsets.DateExpires, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public SquadStatus SquadStatus {
			get {
				return (SquadStatus)(PropertyInvoker.Get<sbyte> (ContractOffsets.SquadStatus, OriginalBytes, MemoryAddress, DatabaseMode));
			}
		}

		public TransferStatus TransferStatus {
			get {
				return (TransferStatus)(PropertyInvoker.Get<sbyte> (ContractOffsets.TransferStatus, OriginalBytes, MemoryAddress, DatabaseMode));
			}
		}

		public sbyte SquadNumber {
			get {
				return PropertyInvoker.Get<sbyte>(ContractOffsets.SquadNumber, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public bool isTransferListed {
			get {
				return ((sbyte)this.TransferStatus == 5) || ((sbyte)this.TransferStatus == 7);
			}
		}

		public ContractClause[] ContractClauses {
			get {
				int numberOfClauses = ProcessManager.ReadArrayLength (MemoryAddress + ContractOffsets.Clauses, ContractClausesOffsets.ClauseLength);
				ContractClause[] result = new ContractClause[numberOfClauses];
				for (int i = 0; i < numberOfClauses; i++) {
					int clauseAddress = PropertyInvoker.Get<Int32> (ContractOffsets.Clauses, OriginalBytes, MemoryAddress, DatabaseMode);
					result [i] = new ContractClause ((clauseAddress + (i * ContractClausesOffsets.ClauseLength)), Version);
				}

				return result;
			}
		}

		public ContractBonus[] ContractBonuses {
			get {
				int numberOfBonuses = ProcessManager.ReadArrayLength (MemoryAddress + ContractOffsets.Bonuses, ContractBonusOffsets.BonusLength);
				ContractBonus[] result = new ContractBonus[numberOfBonuses];
				for (int i = 0; i < numberOfBonuses; i++) {
					int bonusAddress = PropertyInvoker.Get<Int32> (ContractOffsets.Bonuses, OriginalBytes, MemoryAddress, DatabaseMode);
					result [i] = new ContractBonus ((bonusAddress + (i * ContractBonusOffsets.BonusLength)), Version);
				}

				return result;
			}
		}

		public ContractType ContractType {
			get {
				return (ContractType)(PropertyInvoker.Get<sbyte> (ContractOffsets.Type, OriginalBytes, MemoryAddress, DatabaseMode));
			}
		}
	}

	public enum JobType {
		Free = 0,
		Coach = 2,
		Chairman = 4,
		Director = 6,
		ManagingDirector = 8,
		DirectorOfFootball = 10,
		Physio = 12,
		Scout = 14,
		Manager = 16,
		AssistantManager = 20,
		MediaPundit = 22,
		GeneralManager = 24,
		FitnessCoach = 26,
		GoalkeeperCoach = 34,
		U21Manager = 40,
		ChiefScout = 44,
		YouthCoach = 48,
		HeadOfPhysio = 50,
		U19Manager = 52,
		FirstTeamCoach = 54,
		HeadOfYouthDevelopment = 64,
		CaretakerManager = 144
	}

	public enum SquadStatus {
		Invalid = -1,
		NotYetSet = 0,
		KeyPlayer = 1,
		FirstTeamRegular = 2,
		FirstTeamSquadRotation = 3,
		MainBackupPlayer = 4,
		HotProspectForTheFuture = 5,
		DecentYoungster = 6,
		NotNeeded = 7,
		SquadStatusCount = 8
	}

	public enum TransferStatus {
		TransferListed = 5,
		LoadListed = 6,
		TransferAndLoadListed = 7
	}

	public enum ContractType {
		PartTime = 0,
		FullTime = 1,
		Amateur = 2,
		Youth = 3,
		NonContract = 4
	}
}

