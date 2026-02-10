using System;
using System.Collections.Generic;
using System.Linq;

namespace Requirement4
{
    public class ParkingLot
    {
        private string _name;
        private List<Vehicle> _vehicleList;

        public ParkingLot()
        {
            _vehicleList = new List<Vehicle>();
        }

        public ParkingLot(string name, List<Vehicle> vehicleList)
        {
            _name = name;
            _vehicleList = new List<Vehicle>(); // must be empty
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Vehicle> VehicleList
        {
            get { return _vehicleList; }
            set { _vehicleList = value; }
        }

        public void AddVehicleToParkingLot(Vehicle vehicle)
        {
            _vehicleList.Add(vehicle);
        }

        // 🔹 Search by type
        public List<Vehicle> SearchByType(string type)
        {
            return _vehicleList
                .Where(v => v.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // 🔹 Search by parked time
        public List<Vehicle> SearchByParkedTime(DateTime parkedTime)
        {
            return _vehicleList
                .Where(v => v.Ticket.ParkedTime >= parkedTime)
                .ToList();
        }
    }
}
