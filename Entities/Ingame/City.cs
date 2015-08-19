using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Defines.Offsets;
using FMScoutFramework.Core.Managers;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class City : BaseObject
	{
		public City (int memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{	}
		public City (int memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{	}

        public int ID
        {
            get
            {
                return PropertyInvoker.Get<Int32>(CityOffsets.ID, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public int RowID
        {
            get
            {
                return PropertyInvoker.Get<Int32>(CityOffsets.RowID, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public string Name
        {
            get
            {
                return PropertyInvoker.GetString(CityOffsets.Name, -1, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public Nation Nation
        {
            get
            {
                return PropertyInvoker.GetPointer<Nation>(CityOffsets.Nation, OriginalBytes, MemoryAddress, DatabaseMode, Version);
            }
        }

        public short Attraction
        {
            get
            {
                return PropertyInvoker.Get<short>(CityOffsets.Attraction, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public float Latitude
        {
            get
            {
                return PropertyInvoker.Get<float>(CityOffsets.Latitude, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public float Longitude
        {
            get
            {
                return PropertyInvoker.Get<float>(CityOffsets.Longitude, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public short Altitude
        {
            get
            {
                return PropertyInvoker.Get<short>(CityOffsets.Altitude, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
	}
}

