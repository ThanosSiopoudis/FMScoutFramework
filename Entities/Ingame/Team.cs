using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Utilities;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Team : BaseObject
	{
		public Team (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{	}
		public Team (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{	}

		public int RowID {
			get {
				return PropertyInvoker.Get<Int32>(TeamOffsets.RowID, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public int ID {
			get {
				return PropertyInvoker.Get<Int32> (TeamOffsets.ID, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		private int ClubAddress {
			get {
				return PropertyInvoker.Get<Int32> (TeamOffsets.Club, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		private Club Club {
			get {
				return PropertyInvoker.GetPointer<Club> (TeamOffsets.Club, OriginalBytes, MemoryAddress, DatabaseMode, Version);
			}
		}

		private short PreviousReputation {
			get {
				return PropertyInvoker.Get<Int16> (TeamOffsets.PreviousReputation, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public TeamType TeamType {
			get {
				return (TeamType)PropertyInvoker.Get<byte>(TeamOffsets.TeamType, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public ushort Reputation {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_0_Windows) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_1_Windows))
                {
					try{
						int rotateAmount = ((MemoryAddress + TeamOffsets.Reputation) & 15);
						uint encryptedRep = PropertyInvoker.Get<ushort> (TeamOffsets.Reputation, OriginalBytes, MemoryAddress, DatabaseMode);
						encryptedRep = BitwiseOperations.rol_short (encryptedRep, rotateAmount);
						encryptedRep = (encryptedRep ^ 0x130E);
						encryptedRep = BitwiseOperations.rol_short (encryptedRep, 9);
						encryptedRep = ~encryptedRep;

						return (ushort)encryptedRep;
					}
					catch {
						return 0;
					}
				} else {
					return 0;
				}
			}
		}

		public override string ToString ()
		{
			if (this.Club.Name != "-")
				return string.Format ("{0} ({1})", this.Club.Name, this.TeamType.ToString());
			else 
				return "-";
		}
	}

	public enum TeamType {
		First 				= 0,
		Reserves 			= 1,
		A					= 2,
		B 					= 3,
		SuperdraftA			= 4,
		SuperdraftB			= 5,
		SuperdraftC			= 6,
		SuperdraftD			= 7,
		Waivers				= 8,
		U23 				= 9,
		U21 				= 10,
		U19 				= 11,
		U18 				= 12,
		C 					= 13,
		Amateur 			= 14,
		II 					= 15,
		Team2 				= 16,
		Team3 				= 17,
		U20 				= 18,
		YouthEvaluation 	= 22,
		DutchReserves 		= 30
	}
}