using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FMScoutFramework.Core;
using FMScoutFramework.Core.Entities;
using System.Threading;
using FMScoutFramework.Core.Entities.InGame;

namespace UnitTests
{
    [TestClass]
    public class CityTest
    {
        // Test candidate values
        private readonly int uid = 91;
        private readonly string name = "Hellerup";
        private readonly string nation = "Denmark";
        private readonly int attraction = 17;
        private readonly float latitude = 55.737f;
        private readonly float longitude = 12.569f;
        private readonly int altitude = 3;

        private City _testCity = null;

        public City TestCity
        {
            get
            {
                if (_testCity == null)
                {
                    _testCity = GetTestCity();
                }

                return _testCity;
            }
        }

        private City GetTestCity()
        {
            var core = TestHelper.GetLoadedCore();
            return core.Cities.FirstOrDefault(x => x.ID == uid);
        }

        [TestMethod]
        public void CityName()
        {
            Assert.AreEqual(name, TestCity.Name);
        }

        [TestMethod]
        public void CityNation()
        {
            Assert.AreEqual(nation, TestCity.Nation.Name);
        }

        [TestMethod]
        public void CityAttraction()
        {
            Assert.AreEqual(attraction, TestCity.Attraction);
        }

        [TestMethod]
        public void CityLatitude()
        {
            Assert.AreEqual(latitude, TestCity.Latitude, 0.001);
        }

        [TestMethod]
        public void CityLongitude()
        {
            Assert.AreEqual(longitude, TestCity.Longitude, 0.001);
        }

        [TestMethod]
        public void CityAltitude()
        {
            Assert.AreEqual(altitude, TestCity.Altitude);
        }

        [TestMethod]
        public void IsGameLoaded()
        {
            var core = TestHelper.GetLoadedCore();

            try
            {
                core.Clubs.Any();
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsFalse(true);
            }
        }
    }
}
