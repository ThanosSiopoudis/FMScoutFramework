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
            Assert.IsTrue(TestCity.Name == name);
        }

        [TestMethod]
        public void CityNation()
        {
            Assert.IsTrue(TestCity.Nation.Name == nation);
        }

        [TestMethod]
        public void CityAttraction()
        {
            Assert.IsTrue(TestCity.Attraction == attraction);
        }

        [TestMethod]
        public void CityAltitude()
        {
            Assert.IsTrue(TestCity.Altitude == altitude);
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
