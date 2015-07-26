using System;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Utilities;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Person : BaseObject
	{
		public Person (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{
            this.PersonOffsets = new PersonOffsets(version);
        }
        public Person(int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{
            this.PersonOffsets = new PersonOffsets(version);
        }
        public PersonOffsets PersonOffsets;

        public virtual int PersonMemoryAddress
        {
            get
            {
                return -1;
            }
        }

		public int RowID {
			get {
                return PropertyInvoker.Get<Int32>(PersonOffsets.RowID, OriginalBytes, PersonMemoryAddress, DatabaseMode);
			}
		}

		public int ID {
			get {
                return PropertyInvoker.Get<Int32>(PersonOffsets.ID, OriginalBytes, PersonMemoryAddress, DatabaseMode);
			}
		}




	
		public string Fullname {
			get {
                return PropertyInvoker.GetString(PersonOffsets.Fullname, 0, OriginalBytes, PersonMemoryAddress, DatabaseMode);
			}
		}

		public string Nickname {
			get {
                return PropertyInvoker.GetString(PersonOffsets.Nickname, 0, OriginalBytes, PersonMemoryAddress, DatabaseMode);
			}
		}

		public string Firstname {
			get {
                return PropertyInvoker.GetString(PersonOffsets.Firstname, 0x0, OriginalBytes, PersonMemoryAddress, DatabaseMode);
			}
		}

		public string Lastname {
			get {
                return PropertyInvoker.GetString(PersonOffsets.Lastname, 0x0, OriginalBytes, PersonMemoryAddress, DatabaseMode);
			}
		}

		public DateTime DateOfBirth
		{
			get
			{
				return PropertyInvoker.Get<DateTime>(PersonOffsets.DateOfBirth, OriginalBytes, PersonMemoryAddress, DatabaseMode);
			}
		}
		public int Age
		{
			get
			{
				DateTime now = ProcessManager.ReadDateTime(ProcessManager.fmProcess.BaseAddress + Version.MemoryAddresses.CurrentDateTime);
				int age = now.Year - DateOfBirth.Year;
				if (DateOfBirth > now.AddYears(-age))
					age--;
				return age;
			}
		}
		public Contract Contract
		{
			get
			{
				return PropertyInvoker.GetPointer<Contract>(PersonOffsets.Contract, OriginalBytes, PersonMemoryAddress, DatabaseMode, Version);
			}
		}



		public override string ToString () {
			return Firstname + " " + Lastname;
		}
	}
}

