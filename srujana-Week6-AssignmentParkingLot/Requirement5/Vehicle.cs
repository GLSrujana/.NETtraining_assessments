using System;
using System.Globalization;

namespace Requirement5
{
    public class Vehicle : IComparable<Vehicle>
    {
        // Private fields
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;
        private Ticket _ticket;

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

        public Ticket Ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }

        // Parameterized constructor
        public Vehicle(string _registrationNo, string _name, string _type,
                       double _weight, Ticket _ticket)
        {
            this._registrationNo = _registrationNo;
            this._name = _name;
            this._type = _type;
            this._weight = _weight;
            this._ticket = _ticket;
        }

        // STATIC METHOD 
        public static Vehicle CreateVehicle(string detail)
        {
            string[] parts = detail.Split(',');

            Ticket ticket = new Ticket(
                parts[4],
                DateTime.ParseExact(parts[5], "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                double.Parse(parts[6])
            );
            return new Vehicle(
               parts[0],
               parts[1],
               parts[2],
               double.Parse(parts[3]),
               ticket
               );
        }

        // Sort by weight
        public int CompareTo(Vehicle other)
        {
            return this._weight.CompareTo(other._weight);
        }
    }
}
