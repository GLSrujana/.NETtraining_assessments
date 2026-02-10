using System;
using System.Collections.Generic;

namespace Requirement5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            Console.WriteLine("Enter the number of the vehicles:");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                vehicles.Add(Vehicle.CreateVehicle(input));
            }

            Console.WriteLine("Enter a type to sort:");
            Console.WriteLine("1.Sort by weight");
            Console.WriteLine("2.Sort by parked time");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                vehicles.Sort(); // Uses IComparable (Weight)
            }
            else if (choice == 2)
            {
                vehicles.Sort(new parkedTimeComparer());
            }
            else
            {
                Console.WriteLine("Invalid Choice");
                return;
            }

            Console.WriteLine("{0,-15}{1,-10}{2,-15}{3,-10}{4}",
                "Registration No", "Name", "Type", "Weight", "Ticket No");

            foreach (Vehicle v in vehicles)
            {
                Console.WriteLine("{0,-15}{1,-10}{2,-15}{3,-10:F1}{4}",
                    v.RegistrationNo,
                    v.Name,
                    v.Type,
                    v.Weight,
                    v.Ticket.TicketNo);
            }
        }
    }
}
