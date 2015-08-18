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
		}

		public byte Dribbling {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Dribbling, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Finishing {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Finishing, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Heading {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Heading, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte LongShots {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.LongShots, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Marking {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Marking, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte OffTheBall {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.OffTheBall, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Passing {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Passing, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Penalties {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Penalties, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Tackling {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Tackling, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Creativity {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Creativity, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Handling {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Handling, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte AerialAbility {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.AerialAbility, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte CommandOfArea {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.CommandOfArea, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Communication {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Communication, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Kicking {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Kicking, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Throwing {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Throwing, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Anticipation {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Anticipation, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Decisions {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Decisions, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte OneOnOnes {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.OneOnOnes, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Positioning {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Positioning, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Reflexes {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Reflexes, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte FirstTouch {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.FirstTouch, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Technique {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Technique, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte LeftFoot {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.LeftFoot, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte RightFoot {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.RightFoot, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Flair {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Flair, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Corners {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Corners, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Teamwork {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Teamwork, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Workrate {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.WorkRate, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte LongThrows {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.LongThrows, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Eccentricity {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Eccentricity, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte RushingOut {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.RushingOut, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte TendencyToPunch {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.TendencyToPunch, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Acceleration {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Acceleration, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte FreekickTaking {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.FreekickTaking, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Strength {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Strength, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Stamina {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Stamina, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Pace {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Pace, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Jumping {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Jumping, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Influence {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Influence, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Dirtiness {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Dirtiness, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Balance {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Balance, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Bravery {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Bravery, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Consistency {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Consistency, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Aggression {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Aggression, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Agility {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Agility, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte ImportantMatches {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.ImportantMatches, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte InjuryProneness {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.InjuryProneness, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Versatility {
			get {
				return PropertyInvoker.Get<byte> (PlayerStatsOffsets.Versatility, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte NaturalFitness {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.NaturalFitness, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Determination {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Determination, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Composure {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Composure, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public byte Concentration {
			get {
				return PropertyInvoker.Get<byte>(PlayerStatsOffsets.Concentration, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}
	}
}

