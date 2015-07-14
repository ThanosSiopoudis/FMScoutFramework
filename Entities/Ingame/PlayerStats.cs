using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class PlayerStats : BaseObject
	{
		public PlayerStats (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{	}
		public PlayerStats (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{	}

		public byte Goalkeeper {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.GoalKeeper, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Sweeper {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Sweeper, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte DefenderLeft {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.DefenderLeft, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte DefenderCenter {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.DefenderCenter, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte DefenderRight {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.DefenderRight, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte DefensiveMidfielder {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.DefensiveMidfielder, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte MidfielderLeft {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.MidfielderLeft, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte MidfielderCenter {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.MidfielderCenter, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte MidfielderRight {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.MidfielderRight, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte AttackingMidfielderLeft {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.AttackingMidfielderLeft, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte AttackingMidfielderCenter {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.AttackingMidfielderCenter, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte AttackingMidfielderRight {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.AttackingMidfielderRight, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Striker {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Striker, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte WingbackLeft {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.WingbackLeft, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte WingbackRight {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.WingbackRight, OriginalBytes, MemoryAddress, DatabaseMode);
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
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Crossing, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Dribbling {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Dribbling, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Finishing {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Finishing, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Heading {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Heading, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte LongShots {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.LongShots, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Marking {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Marking, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte OffTheBall {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.OffTheBall, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Passing {
			get {
                return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Passing, OriginalBytes, MemoryAddress, DatabaseMode);
            }
		}

		public byte Penalties {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Penalties, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Tackling {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Tackling, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Creativity {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Creativity, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Handling {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Handling, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte AerialAbility {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.AerialAbility, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte CommandOfArea {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.CommandOfArea, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Communication {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Communication, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Kicking {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Kicking, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Throwing {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Throwing, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Anticipation {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Anticipation, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Decisions {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Decisions, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte OneOnOnes {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.OneOnOnes, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Positioning {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Positioning, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Reflexes {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Reflexes, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte FirstTouch {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.FirstTouch, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Technique {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Technique, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte LeftFoot {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.LeftFoot, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte RightFoot {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.RightFoot, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Flair {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Flair, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Corners {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Corners, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Teamwork {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Teamwork, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Workrate {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.WorkRate, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte LongThrows {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.LongThrows, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Eccentricity {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Eccentricity, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte RushingOut {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.RushingOut, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte TendencyToPunch {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.TendencyToPunch, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Acceleration {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Acceleration, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte FreekickTaking {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.FreekickTaking, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Strength {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Strength, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Stamina {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Stamina, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Pace {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Pace, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Jumping {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Jumping, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Influence {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Influence, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Dirtiness {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Dirtiness, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Balance {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Balance, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Bravery {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Bravery, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Consistency {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Consistency, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Aggression {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Aggression, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Agility {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Agility, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte ImportantMatches {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.ImportantMatches, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte InjuryProneness {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.InjuryProneness, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Versatility {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Versatility, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte NaturalFitness {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.NaturalFitness, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Determination {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Determination, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Composure {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Composure, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Concentration {
			get {
				return PropertyInvoker.GetPlayerAttribute(PlayerStatsOffsets.Concentration, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}
	}
}

