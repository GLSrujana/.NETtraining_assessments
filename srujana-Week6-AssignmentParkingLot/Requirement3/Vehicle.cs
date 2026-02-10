using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Requirement3
{
    public class Vehicle
    {
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;
        private Ticket _ticket;

        public string RegistrationNo
        {
            get { return _registrationNo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Registration number cannot be empty");
                _registrationNo = value;
            }
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
            set
            {
                if (value < 0)
                    throw new ArgumentException("Weight must be positive");
                _weight = value;
            }
        }

        public Ticket Ticket
        {
            get { return _ticket; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Ticket cannot be null");
                _ticket = value;

            }
        }

        public Vehicle(string _registrationNo, string _name, string _type, double _weight, Ticket _ticket)
        {

            if (string.IsNullOrWhiteSpace(_registrationNo))
                throw new ArgumentException("Registration number cannot be empty");

            if (string.IsNullOrWhiteSpace(_name))
                throw new ArgumentException("Vehicle name cannot be empty");

            RegistrationNo = _registrationNo;
            Name = _name;
            Type = _type;
            Weight = _weight;
            Ticket = _ticket;
        }

        public override string ToString()
        {
            return $"Registration No.: {_registrationNo}\n" +
                    $"Name: {_name}\n" +
                    $"Type: {_type}\n" +
                    $"Weight: {_weight}\n" +
                    $"Ticket No.: {_ticket?.TicketNo}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Vehicle))
                return false;

            Vehicle other = (Vehicle)obj;

            return string.Equals(this._registrationNo, other._registrationNo, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(this._name, other._name, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return (_registrationNo + _name).ToLower().GetHashCode();
        }

    }
}