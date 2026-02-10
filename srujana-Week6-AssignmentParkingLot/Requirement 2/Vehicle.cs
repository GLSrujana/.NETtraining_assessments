using System;
using System.Globalization;

namespace Requirement2
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

        public Vehicle(string registrationNo, string name, string type, double weight, Ticket ticket)
        {
            RegistrationNo = registrationNo;
            Name = name;
            Type = type;
            Weight = weight;
            Ticket = ticket;
        }

        // ✅ STATIC METHOD AS REQUIRED
        public static Vehicle CreateVehicle(string detail)
        {
            try
            {
                string[] parts = detail.Split(',');

                if (parts.Length != 7)
                    throw new FormatException("Invalid input format");

                Ticket ticket = new Ticket(
                    parts[4].Trim(),
                    DateTime.ParseExact(parts[5].Trim(), "dd-MM-yyyy HH:mm:ss", null),
                    double.Parse(parts[6].Trim(), CultureInfo.InvariantCulture)
                );

                return new Vehicle(
                    parts[0].Trim(),
                    parts[1].Trim(),
                    parts[2].Trim(),
                    double.Parse(parts[3].Trim(), CultureInfo.InvariantCulture),
                    ticket
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating Vehicle: " + ex.Message);
                return null;
            }
        }

        public override string ToString()
        {
            return $"Registration No.: {RegistrationNo}\n" +
                   $"Name: {Name}\n" +
                   $"Type: {Type}\n" +
                   $"Weight: {Weight:F1}\n" +
                   $"Ticket No.: {Ticket.TicketNo}\n" +
                   $"Parked Time: {Ticket.ParkedTime:dd-MM-yyyy HH:mm:ss}\n" +
                   $"Cost: {Ticket.Cost:F1}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Vehicle v)
            {
                return RegistrationNo.Equals(v.RegistrationNo, StringComparison.OrdinalIgnoreCase)
                    && Name.Equals(v.Name, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (RegistrationNo + Name).ToLower().GetHashCode();
        }
    }
}
