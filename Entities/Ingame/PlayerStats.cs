using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Entities.InGame.Interfaces;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class PlayerStats : BaseObject, IPlayerStats
    {
		public PlayerStats (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{	}
		public PlayerStats (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{	}

		public byte Goalkeeper {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.GoalKeeper, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Sweeper {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Sweeper, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte DefenderLeft {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.DefenderLeft, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte DefenderCenter {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.DefenderCenter, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte DefenderRight {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.DefenderRight, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte DefensiveMidfielder {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.DefensiveMidfielder, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte MidfielderLeft {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.MidfielderLeft, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte MidfielderCenter {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.MidfielderCenter, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte MidfielderRight {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.MidfielderRight, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte AttackingMidfielderLeft {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.AttackingMidfielderLeft, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte AttackingMidfielderCenter {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.AttackingMidfielderCenter, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte AttackingMidfielderRight {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.AttackingMidfielderRight, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Striker {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Striker, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte WingbackLeft {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.WingbackLeft, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte WingbackRight {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.WingbackRight, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public string Position {
			get {
				string final = "";
				if (Goalkeeper == 20) {
					if (final.Length > 0)
						final += ", ";
					final += "GK";
				}
				if (Sweeper == 20) {
					if (final.Length > 0)
						final += ", ";
					final += "SW";
				}
				if (DefenderLeft == 20 || DefenderCenter == 20 || DefenderRight == 20) {
					if (final.Length > 0)
						final += ", ";
					final += "D ";
					if (DefenderRight == 20)
						final += "R";
					if (DefenderLeft == 20)
						final += "L";
					if (DefenderCenter == 20)
						final += "C";
				}
				if (WingbackLeft == 20 || WingbackRight == 20) {
					if (final.Length > 0)
						final += ", ";
					final += "WB ";
					if (WingbackRight == 20)
						final += "R";
					if (WingbackLeft == 20)
						final += "L";
				}
				if (DefensiveMidfielder == 20) {
					if (final.Length > 0)
						final += ", ";
					final += "DM";
				}
				if (AttackingMidfielderLeft == 20 || AttackingMidfielderCenter == 20 || AttackingMidfielderRight == 20) {
					if (final.Length > 0)
						final += ", ";
					final += "AM ";
				} else if (MidfielderLeft == 20 || MidfielderCenter == 20 || MidfielderRight == 20) {
					if (final.Length > 0)
						final += ", ";
					final += "M ";
				}
				if (AttackingMidfielderLeft == 20 || AttackingMidfielderCenter == 20 || AttackingMidfielderRight == 20 ||
				    MidfielderLeft == 20 || MidfielderCenter == 20 || MidfielderRight == 20) {
					if (AttackingMidfielderRight == 20 || MidfielderRight == 20)
						final += "R";
					if (AttackingMidfielderLeft == 20 || MidfielderLeft == 20)
						final += "L";
					if (AttackingMidfielderCenter == 20 || MidfielderCenter == 20)
						final += "C";
				}
				if (Striker == 20) {
					if (final.Length > 0)
						final += ", ";
					final += "F C";
				}

				return final;
			}
		}

		public byte Crossing {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Crossing, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Crossing, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
		}

		public byte Dribbling {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Dribbling, OriginalBytes, MemoryAddress, DatabaseMode);
            }
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Dribbling, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Finishing {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Finishing, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Finishing, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Heading {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Heading, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Heading, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte LongShots {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.LongShots, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.LongShots, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Marking {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Marking, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Marking, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte OffTheBall {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.OffTheBall, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.OffTheBall, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Passing {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Passing, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Passing, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Penalties {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Penalties, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Penalties, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Tackling {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Tackling, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Tackling, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Creativity {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Creativity, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Creativity, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Handling {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Handling, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Handling, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte AerialAbility {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.AerialAbility, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.AerialAbility, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte CommandOfArea {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.CommandOfArea, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.CommandOfArea, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Communication {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Communication, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Communication, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Kicking {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Kicking, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Kicking, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Throwing {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Throwing, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Throwing, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Anticipation {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Anticipation, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Anticipation, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Decisions {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Decisions, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Decisions, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte OneOnOnes {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.OneOnOnes, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.OneOnOnes, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Positioning {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Positioning, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Positioning, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Reflexes {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Reflexes, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Reflexes, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte FirstTouch {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.FirstTouch, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.FirstTouch, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Technique {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Technique, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Technique, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte LeftFoot {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.LeftFoot, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.LeftFoot, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte RightFoot {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.RightFoot, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.RightFoot, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Flair {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Flair, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Flair, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Corners {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Corners, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Corners, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
		}

		public byte Teamwork {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Teamwork, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Teamwork, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Workrate {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.WorkRate, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.WorkRate, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte LongThrows {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.LongThrows, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.LongThrows, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Eccentricity {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Eccentricity, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Eccentricity, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte RushingOut {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.RushingOut, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.RushingOut, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte TendencyToPunch {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.TendencyToPunch, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.TendencyToPunch, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Acceleration {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Acceleration, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Acceleration, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte FreekickTaking {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.FreekickTaking, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.FreekickTaking, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Strength {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Strength, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Strength, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Stamina {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Stamina, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Stamina, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Pace {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Pace, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Pace, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Jumping {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Jumping, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Jumping, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Influence {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Influence, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Influence, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Dirtiness {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Dirtiness, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Dirtiness, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Balance {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Balance, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Balance, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Bravery {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Bravery, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Bravery, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Consistency {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Consistency, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Consistency, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Aggression {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Aggression, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Aggression, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Agility {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Agility, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Agility, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte ImportantMatches {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.ImportantMatches, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.ImportantMatches, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte InjuryProneness {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.InjuryProneness, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.InjuryProneness, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Versatility {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Versatility, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Versatility, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte NaturalFitness {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.NaturalFitness, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.NaturalFitness, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Determination {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Determination, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Determination, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Composure {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Composure, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Composure, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public byte Concentration {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Concentration, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerStatsOffsets.Concentration, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }
	}
}

