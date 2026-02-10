using System;
using System.Collections.Generic;

namespace Requirement6
{
    public class Vehicle
    {
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;

        // Default constructor
        public Vehicle() { }

        // Parameterized constructor
        public Vehicle(string _registrationNo, string _name, string _type, double _weight)
        {
            this._registrationNo = _registrationNo;
            this._name = _name;
            this._type = _type;
            this._weight = _weight;
        }

        // Properties
        public string RegistrationNo
        {
            get { return _registrationNo; }
            set { _registrationNo = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        // static methods

        // a) CreateVehicle
        public static Vehicle CreateVehicle(string detail)
        {
            string[] parts = detail.Split(',');

            return new Vehicle(
                parts[0],
                parts[1],
                parts[2],
                double.Parse(parts[3])
            );
        }

        // b) TypeWiseCount
        public static SortedDictionary<string, int> TypeWiseCount(List<Vehicle> vehicleList)
        {
            SortedDictionary<string, int> result = new SortedDictionary<string, int>();

            foreach (Vehicle v in vehicleList)
            {
                if (result.ContainsKey(v.Type))
                {
                    result[v.Type]++;
                }
                else
                {
                    result[v.Type] = 1;
                }
            }

            return result;
        }
    }
}
