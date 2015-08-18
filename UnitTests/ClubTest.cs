using FMScoutFramework.Core.Entities.InGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class ClubTest
    {
        // Test candidate values
        private readonly int uid = 512;
        private readonly string cityName = "Hellerup";

        private Club _testClub;

        public Club TestClub
        {
            get
            {
                if (_testClub == null)
                {
                    _testClub = GetTestClub();
                }

                return _testClub;
            }
        }

        private Club GetTestClub()
        {
            var core = TestHelper.GetLoadedCore();
            return core.Clubs.FirstOrDefault(x => x.ID == uid);
        }

        [TestMethod]
        public void ClubCityTest()
        {
            Assert.AreEqual(cityName, TestClub.City.Name);
        }
    }
}
