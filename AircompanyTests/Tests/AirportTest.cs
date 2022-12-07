using Aircompany;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AircompanyTests.Tests
{
    /// <summary>
    /// Contains unit tests for Airport class
    /// </summary>
    [TestFixture]
    public class AirportTest
    {
        /// <summary>
        /// Plane list referenced by all tests
        /// </summary>
        private List<Plane> planes;

        [SetUp]
        public void SetUp()
        {
            planes = new List<Plane>()
            {
                new PassengerPlane("Boeing-737", 900, 12000, 60500, 164),
                new PassengerPlane("Boeing-737-800", 940, 12300, 63870, 192),
                new PassengerPlane("Boeing-747", 980, 16100, 70500, 242),
                new PassengerPlane("Airbus A320", 930, 11800, 65500, 188),
                new PassengerPlane("Airbus A330", 990, 14800, 80500, 222),
                new PassengerPlane("Embraer 190", 870, 8100, 30800, 64),
                new PassengerPlane("Sukhoi Superjet 100", 870, 11500, 50500, 140),
                new PassengerPlane("Bombardier CS300", 920, 11000, 60700, 196),
                new MilitaryPlane("B-1B Lancer", 1050, 21000, 80000, MilitaryType.BOMBER),
                new MilitaryPlane("B-2 Spirit", 1030, 22000, 70000, MilitaryType.BOMBER),
                new MilitaryPlane("B-52 Stratofortress", 1000, 20000, 80000, MilitaryType.BOMBER),
                new MilitaryPlane("F-15", 1500, 12000, 10000, MilitaryType.FIGHTER),
                new MilitaryPlane("F-22", 1550, 13000, 11000, MilitaryType.FIGHTER),
                new MilitaryPlane("C-130 Hercules", 650, 5000, 110000, MilitaryType.TRANSPORT)
            };
        }

        [TearDown]
        public void TearDown()
        {
            planes = null;
        }

        [Test]
        public void GetTransportMilitaryPlanes_WhenCalled_ReturnsMilitaryPlanesList()
        {
            Airport airport = new Airport(planes);

            List<MilitaryPlane> transportMilitaryPlanes = airport.GetTransportMilitaryPlanes().ToList();
            bool hasMilitaryTransportPlane = false;
            foreach (MilitaryPlane militaryPlane in transportMilitaryPlanes)
            {
                if ((militaryPlane.PlaneType == MilitaryType.TRANSPORT))
                {
                    hasMilitaryTransportPlane = true;
                }
            }

            Assert.IsTrue(hasMilitaryTransportPlane);
        }

        [Test]
        public void GetPassengerPlaneWithMaxPassengersCapacity_WhenCalled_ReturnsMaxCapacityPassengerPlane()
        {
            Airport airport = new Airport(planes);
            PassengerPlane planeWithMaxPassengerCapacity = new PassengerPlane("Boeing-747", 980, 16100, 70500, 242);

            PassengerPlane actualPlaneWithMaxPassengersCapacity = airport.GetPassengerPlaneWithMaxPassengersCapacity();

            Assert.AreEqual(planeWithMaxPassengerCapacity, actualPlaneWithMaxPassengersCapacity);
        }

        [Test]
        public void SortByMaxLoadCapacity_WhenCalled_SortsPlanesListByMaxLoadCapacity()
        {
            Airport airport = new Airport(planes);
            airport = airport.SortByMaxLoadCapacity();
            List<Plane> planesSortedByMaxLoadCapacity = airport.GetPlanes().ToList();

            bool nextPlaneMaxLoadCapacityIsHigherThanCurrent = true;
            for (int i = 0; i < planesSortedByMaxLoadCapacity.Count - 1; i++)
            {
                Plane currentPlane = planesSortedByMaxLoadCapacity[i];
                Plane nextPlane = planesSortedByMaxLoadCapacity[i + 1];
                if (currentPlane.MAXLoadCapacity > nextPlane.MAXLoadCapacity)
                {
                    nextPlaneMaxLoadCapacityIsHigherThanCurrent = false;
                }
            }

            Assert.IsTrue(nextPlaneMaxLoadCapacityIsHigherThanCurrent);
        }
    }
}
