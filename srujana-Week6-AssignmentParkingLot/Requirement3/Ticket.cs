using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement3
{
    public class Ticket
    {
        private string _ticketNo;
        private DateTime _parkedTime;
        private double _cost;

        public string TicketNo
        {
            get { return _ticketNo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ticket number cannot be empty");
                _ticketNo = value;
            }
        }

        public DateTime ParkedTime
        {
            get { return _parkedTime; }
            set{ _parkedTime = value; }
        }

        public double Cost
        {
            get { return _cost; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Cost cannot be negative");
                _cost = value;
            }
        }


        public Ticket(string _ticketNo, DateTime _parkedTime, double _cost)
        {
            TicketNo = _ticketNo;
            ParkedTime = _parkedTime;
            Cost = _cost;
        }

        public override string ToString()
        {
            return $"Ticket No: {TicketNo}, Parked Time: {ParkedTime}, Cost: {Cost:C}";
        }
    }
}
