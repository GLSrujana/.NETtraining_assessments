using System;

namespace Requirement1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Read first vehicle input
                Console.WriteLine("Enter Vehicle 1 details:");
                string input1 = Console.ReadLine();
                string[] v1 = input1.Split(',');

                // Create Ticket object for Vehicle 1
                Ticket ticket1 = new Ticket(
                    v1[4],
                    DateTime.Parse(v1[5]),
                    double.Parse(v1[6])
                );

                // Create Vehicle object for Vehicle 1
                Vehicle vehicle1 = new Vehicle(
                    v1[0],
                    v1[1],
                    v1[2],
                    double.Parse(v1[3]),
                    ticket1
                );

                // Read second vehicle input
                Console.WriteLine("Enter Vehicle 2 details:");
                string input2 = Console.ReadLine();
                string[] v2 = input2.Split(',');

                // Create Ticket object for Vehicle 2
                Ticket ticket2 = new Ticket(
                    v2[4],
                    DateTime.Parse(v2[5]),
                    double.Parse(v2[6])
                );

                // Create Vehicle object for Vehicle 2
                Vehicle vehicle2 = new Vehicle(
                    v2[0],
                    v2[1],
                    v2[2],
                    double.Parse(v2[3]),
                    ticket2
                );

                                
            
                // Display vehicle details
                Console.WriteLine(vehicle1);
                Console.WriteLine();   // Empty line as per requirement
                Console.WriteLine(vehicle2);
                Console.WriteLine();   // Empty line as per requirement

                // Compare vehicles
                if (vehicle1.Equals(vehicle2))
                    Console.WriteLine("Vehicle 1 is same as Vehicle 2");
                else
                    Console.WriteLine("Vehicle 1 and Vehicle 2 are different");
            }
            catch (Exception ex)
            {
                // Generic exception handling (mandatory as per instruction)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
