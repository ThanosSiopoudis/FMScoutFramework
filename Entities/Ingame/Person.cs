using System;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Entities.InGame.Interfaces;
using FMScoutFramework.Core.Utilities;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Person : BaseObject, IPerson
    {
		public PersonOffsets PersonOffsets;
		public Person (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{
			this.PersonOffsets = new PersonOffsets(version);
		}
		public Person (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{
			this.PersonOffsets = new PersonOffsets(version);
		}

		protected virtual int PersonAddress {
			get {
				return (MemoryAddress + Version.PersonOffsets.Person);
			}
		}

		public DateTime DateOfBirth {
			get {
				return PropertyInvoker.Get<DateTime> (PersonOffsets.DateOfBirth, OriginalBytes, PersonAddress, DatabaseMode);
			}
		}

		public int Age {
			get {
				DateTime now = DateTime.Today;
				int age = now.Year - DateOfBirth.Year;
				if (DateOfBirth > now.AddYears (-age))
					age--;
				return age;
			}
		}

		public string Fullname {
			get {
				return PropertyInvoker.GetString (PersonOffsets.Fullname, -1, OriginalBytes, PersonAddress, DatabaseMode);
			}
		}

		public string Nickname {
			get {
				return PropertyInvoker.GetString(PersonOffsets.Nickname, Version.MemoryAddresses.StringOffset, OriginalBytes, PersonAddress, DatabaseMode);
			}
		}

		public string Firstname {
			get {
				return PropertyInvoker.GetString(PersonOffsets.Firstname, Version.MemoryAddresses.StringOffset, OriginalBytes, PersonAddress, DatabaseMode);
			}
		}

		public string Lastname {
			get {
				return PropertyInvoker.GetString(PersonOffsets.Lastname, Version.MemoryAddresses.StringOffset, OriginalBytes, PersonAddress, DatabaseMode);
			}
		}

		public Nation Nationality {
			get {
				return PropertyInvoker.GetPointer<Nation> (PersonOffsets.Nationality, OriginalBytes, PersonAddress, DatabaseMode, Version);
			}
		}

		public PersonAttributes Attributes {
			get {
				int AttributesAddress = PersonAddress + PersonOffsets.Attributes;
				return new PersonAttributes (AttributesAddress, Version);
			}
		}

		public Contract Contract {
			get {
				return PropertyInvoker.GetPointer<Contract> (PersonOffsets.Contract, OriginalBytes, PersonAddress, DatabaseMode, Version);
			}
		}

		public Club Club {
			get {
				return PropertyInvoker.GetPointer<Club> (PersonOffsets.Club, OriginalBytes, PersonAddress, DatabaseMode, Version);
			}
		}
	}
}