using System;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Utilities;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Player : Person
	{
        public PlayerOffsets PlayerOffsets;
		public Player (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{
            this.PlayerOffsets = new PlayerOffsets(version);
        }
		public Player (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{
            this.PlayerOffsets = new PlayerOffsets(version);
        }

        public override int PersonMemoryAddress
        {
            get
            {
                return MemoryAddress + Math.Abs(Version.PersonOffsets.Player);
            }
        }

		public PlayerStats PlayerStats {
			get {
				int startAddress = MemoryAddress + PlayerOffsets.PlayerStats;
				return new PlayerStats (startAddress, Version);
			}
		}

		public Int32 InjuriesAddress {
			get {
				return PropertyInvoker.Get<Int32> (PlayerOffsets.Injuries, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public Injury[] Injuries {
			get {
				int numberOfInjuries = ProcessManager.ReadArrayLength (InjuriesAddress);
				Injury[] retVal = new Injury[numberOfInjuries];
				for (int i = 0; i < numberOfInjuries; i++) {
					int injuryAddress = PropertyInvoker.Get<Int32> ((i * 4), OriginalBytes, InjuriesAddress, DatabaseMode);
					injuryAddress = PropertyInvoker.Get<Int32> (0x0, OriginalBytes, injuryAddress, DatabaseMode);
					retVal [i] = PropertyInvoker.GetPointer<Injury> (0x8, OriginalBytes, injuryAddress, DatabaseMode, Version);
				}

				return retVal;
			}
		}

		public bool isInjured {
			get {
				return (Injuries.Length > 0);
			}
		}

		public Int32 BansAddress {
			get {
				return PropertyInvoker.Get<Int32> (PlayerOffsets.BansOffset, OriginalBytes, InjuriesAddress, DatabaseMode);
			}
		}

		public bool isBanned {
			get {
				return ProcessManager.ReadArrayLength (BansAddress) > 0;
			}
		}

		public Team Team {
			get {
				return PropertyInvoker.GetPointer<Team> (PlayerOffsets.Team, OriginalBytes, MemoryAddress, DatabaseMode, Version);
			}
		}

		public int Value {
			get {
				return PropertyInvoker.Get<Int32> (PlayerOffsets.Value, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public int AskingPrice {
			get {
				return PropertyInvoker.Get<Int32> (PlayerOffsets.AskingPrice, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public short Fitness {
			get {
				return PropertyInvoker.Get<short> (PlayerOffsets.Fitness, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public short Jadedness {
			get {
				return PropertyInvoker.Get<short> (PlayerOffsets.Jadedness, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public short Condition {
			get {
				return PropertyInvoker.Get<short> (PlayerOffsets.Condition, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public short HomeReputation {
			get {
				return PropertyInvoker.Get<short> (PlayerOffsets.HomeReputation, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public short CurrentReputation {
			get {
				return PropertyInvoker.Get<short> (PlayerOffsets.CurrentReputation, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public short WorldReputation {
			get {
				return PropertyInvoker.Get<short> (PlayerOffsets.WorldReputation, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public ushort CA {
			get {
				if (Version.GetType () == typeof(Steam_14_3_0_Linux) ||
					Version.GetType() == typeof(Steam_14_3_0_Windows) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_1_Windows))
                {
					try {
						int rotateAmount = ((MemoryAddress + PlayerOffsets.CA) & 15);
						uint encryptedVal = PropertyInvoker.Get<ushort> (PlayerOffsets.CA, OriginalBytes, MemoryAddress, DatabaseMode);
						encryptedVal = BitwiseOperations.ror_short (encryptedVal, rotateAmount);
						encryptedVal = encryptedVal ^ 0x4B3F;
						encryptedVal = BitwiseOperations.ror_short (encryptedVal, 11);
						encryptedVal = encryptedVal ^ 0xFFFF;
						encryptedVal = BitwiseOperations.ror_short (encryptedVal, 12);

						return (ushort)encryptedVal;
					} catch {
						return 4;
					}
				} 
                else if (Version.GetType() == typeof(Steam_15_3_2_Windows))
                {
                    int rotateAmount = ((MemoryAddress + PlayerOffsets.CA) & 15);
                    uint encryptedVal = PropertyInvoker.Get<ushort>(PlayerOffsets.CA, OriginalBytes, MemoryAddress, DatabaseMode);
                    encryptedVal = BitwiseOperations.ror_short(encryptedVal, 7);
                    encryptedVal = (ushort)~encryptedVal;
                    encryptedVal = BitwiseOperations.ror_short(encryptedVal, rotateAmount);
                    encryptedVal = (ushort)~encryptedVal;
                    encryptedVal = BitwiseOperations.ror_short(encryptedVal, 5);

                    return (ushort)encryptedVal;
                }
                else {
					return 2;
				}
			}
		}

		public ushort PA {
			get {
                if (Version.GetType() == typeof(Steam_14_3_0_Linux) || 
					Version.GetType() == typeof(Steam_14_3_0_Windows) ||
					Version.GetType() == typeof(Steam_14_3_0_Mac) ||
                    Version.GetType() == typeof(Steam_14_3_1_Linux) ||
                    Version.GetType() == typeof(Steam_14_3_1_Windows))
                {
					try {
						int rotateAmount = ((MemoryAddress + PlayerOffsets.PA) & 15);
						uint encryptedVal = (uint)PropertyInvoker.Get<ushort> (PlayerOffsets.PA, OriginalBytes, MemoryAddress, DatabaseMode);

						encryptedVal = BitwiseOperations.ror_short (encryptedVal, rotateAmount);
						encryptedVal = encryptedVal ^ 0xB0F8;

						return (ushort)encryptedVal;
					} catch {
						return 0;
					}
				}
				else if (Version.GetType() == typeof(Steam_15_3_2_Windows))
				{
					try
					{
						int rotateAmount = ((MemoryAddress + PlayerOffsets.PA) & 15);
						ushort encryptedVal = PropertyInvoker.Get<ushort>(PlayerOffsets.PA, OriginalBytes, MemoryAddress, DatabaseMode);

						encryptedVal = (ushort)~encryptedVal;
						encryptedVal = (ushort)BitwiseOperations.rol_short((uint)encryptedVal, 6);
						encryptedVal = (ushort)(encryptedVal ^ 35380);
						encryptedVal = (ushort)~encryptedVal;
						encryptedVal = (ushort)BitwiseOperations.ror_short((uint)encryptedVal, rotateAmount);
						return encryptedVal;
					}
					catch
					{
						return 0;
					}
				}
				else
				{
					return 0;
				}
			}
		}

		public ushort Weight {
			get {
				return PropertyInvoker.Get<ushort> (PlayerOffsets.Weight, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public ushort Height {
			get {
				return PropertyInvoker.Get<ushort> (PlayerOffsets.Height, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public PersonAttributes Attributes {
			get {
				int AttributesAddress = MemoryAddress + PlayerOffsets.Attributes;
				return new PersonAttributes (AttributesAddress, Version);
			}
		}

		

		

		public byte InternationalApps {
			get {
				return PropertyInvoker.Get<byte> (PlayerOffsets.InternationalApps, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte U21InternationalApps {
			get {
				return PropertyInvoker.Get<byte> (PlayerOffsets.U21InternationalApps, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte InternationalGoals {
			get {
				return PropertyInvoker.Get<byte> (PlayerOffsets.InternationalGoals, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte U21InternationalGoals {
			get {
				return PropertyInvoker.Get<byte> (PlayerOffsets.U21InternationalGoals, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public double GrowthPotential {
			get {
				if (PlayerStats != null && Attributes != null) {
					double DAP = (((PlayerStats.Determination / 5) * 0.05) + (Attributes.Ambition * 0.09) + (Attributes.Professionalism * 0.115));
					if (Age < 24) {
						if (PA <= (CA + 10)) {
							DAP -= 0.5;
						}
					} else if (Age >= 24 && Age < 29) {
						DAP -= 0.5;
						if (PA <= (CA + 10)) {
							DAP -= 0.5;
						}
					} else if (Age >= 29 && Age < 34) {
						DAP -= 1.0;
						if (PA <= (CA + 10)) {
							DAP -= 0.5;
						}
					} else if (Age >= 34) {
						if (PA <= (CA + 10) && PlayerStats.Goalkeeper >= 15) {
							DAP = 0.5;
						} else {
							DAP = 0.0;
						}
					}

					DAP *= 2.0;
					DAP = Math.Round (DAP, MidpointRounding.AwayFromZero);
					DAP /= 2.0;

					return DAP;
				}

				return 0.0;
			}
		}

		public override string ToString () {
			return Firstname + " " + Lastname;
		}
	}
}

