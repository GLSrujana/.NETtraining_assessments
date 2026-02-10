using System;
using System.Collections.Generic;

namespace Requirement2
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
            _vehicleList = new List<Vehicle>(); // must be empty initially
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
            Console.WriteLine("Vehicle added successfully");
        }

        public bool RemoveVehicleFromParkingLot(string registrationNo)
        {
            foreach (Vehicle v in _vehicleList)
            {
                if (v.RegistrationNo.Equals(registrationNo, StringComparison.OrdinalIgnoreCase))
                {
                    _vehicleList.Remove(v);
                    return true;
                }
            }
            return false;
        }

        public void DisplayVehicles()
        {
            if (_vehicleList.Count == 0)
            {
                Console.WriteLine("Parking Lot is empty");
                return;
            }

            Console.WriteLine($"Vehicles in Parking Lot: {Name}");
            foreach (Vehicle v in _vehicleList)
            {
                Console.WriteLine(v);
                Console.WriteLine();
            }
        }
    }
}
