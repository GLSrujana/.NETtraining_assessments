using System;

namespace Requirement4
{
    public class Vehicle
    {
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;
        private Ticket _ticket;

        public Vehicle() { }

        public Vehicle(string registrationNo, string name, string type, double weight, Ticket ticket)
        {
            _registrationNo = registrationNo;
            _name = name;
            _type = type;
            _weight = weight;
            _ticket = ticket;
        }

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

        // 🔹 Requirement: CreateVehicle
        public static Vehicle CreateVehicle(string detail)
        {
            string[] data = detail.Split(',');

            Ticket ticket = new Ticket(
                data[4],
                DateTime.ParseExact(data[5], "dd-MM-yyyy HH:mm:ss", null),
                double.Parse(data[6])
            );

            return new Vehicle(
                data[0],
                data[1],
                data[2],
                double.Parse(data[3]),
                ticket
            );
        }

        public override string ToString()
        {
            return $"{RegistrationNo,-15}{Name,-10}{Type,-15}{Weight,-10:F1}{Ticket.TicketNo}";
        }
    }
}
