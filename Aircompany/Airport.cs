using Aircompany.Models;
using Aircompany.Planes;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    /// <summary>
    /// Models an Airport with planes
    /// </summary>
    public class Airport
    {
        /// <summary>
        /// Holds the set of planes
        /// </summary>
        private List<Plane> planes;

        public Airport(IEnumerable<Plane> planes)
        {
            this.planes = planes.ToList();
        }

        /// <summary>
        /// Get passenger planes
        /// </summary>
        /// <returns>PassengerPlane type planes List</returns>
        public List<PassengerPlane> GetPassengersPlanes()
        {
            List<PassengerPlane> passengerPlanes = new List<PassengerPlane>();
            for (int i=0; i < planes.Count; i++)
            {
                if (planes[i].GetType() == typeof(PassengerPlane))
                {
                    passengerPlanes.Add((PassengerPlane)planes[i]);
                }
            }
            return passengerPlanes;
        }

        /// <summary>
        /// Get military planes
        /// </summary>
        /// <returns>MilitaryPlane type planes List</returns>
        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            List<MilitaryPlane> militaryPlanes = new List<MilitaryPlane>();
            for (int i = 0; i < planes.Count; i++)
            {
                if (planes[i].GetType() == typeof(MilitaryPlane))
                {
                    militaryPlanes.Add((MilitaryPlane)planes[i]);
                }
            }
            return militaryPlanes;
        }

        /// <summary>
        /// Get the passenger plane with maximum passenger capacity
        /// </summary>
        /// <returns>PassengerPlane object having maximum passenger capacity</returns>
        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            List<PassengerPlane> passengerPlanes = GetPassengersPlanes();
            return passengerPlanes.Aggregate((w, x) => w.PassengersCapacity > x.PassengersCapacity ? w : x);             
        }

        /// <summary>
        /// Get the military planes with PlaneType == MilitaryType.TRANSPORT
        /// </summary>
        /// <returns>MilitaryPlane list with PlaneType == MilitaryType.TRANSPORT</returns>

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            List<MilitaryPlane> transportMilitaryPlanes = new List<MilitaryPlane>();
            List<MilitaryPlane> militaryPlanes = GetMilitaryPlanes();
            for (int i = 0; i < militaryPlanes.Count; i++)
            {
                MilitaryPlane plane = militaryPlanes[i];
                if (plane.PlaneType == MilitaryType.TRANSPORT)
                {
                    transportMilitaryPlanes.Add(plane);
                }
            }

            return transportMilitaryPlanes;
        }

        /// <summary>
        /// Sorts the planes by max distance
        /// </summary>
        /// <returns>Airport sorted with planes by max distance</returns>
        public Airport SortByMaxDistance()
        {
            return new Airport(planes.OrderBy(w => w.MAXFlightDistance));
        }

        /// <summary>
        /// Sorts the planes by max speed
        /// </summary>
        /// <returns>Airport sorted with planes by max speed</returns>
        public Airport SortByMaxSpeed()
        {
            return new Airport(planes.OrderBy(w => w.MaxSpeed));
        }

        /// <summary>
        /// Sorts the planes by max load capacity
        /// </summary>
        /// <returns>Airport sorted with planes by max load capacity</returns>
        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(planes.OrderBy(w => w.MAXLoadCapacity));
        }

        /// <summary>
        /// Get all planes in Airport
        /// </summary>
        /// <returns>All planes in Airport as IEnumerable</returns>
        public IEnumerable<Plane> GetPlanes()
        {
            return planes;
        }

        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", planes.Select(x => x.Model)) +
                    '}';
        }
    }
}
