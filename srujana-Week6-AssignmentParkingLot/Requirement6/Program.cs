using System;
using System.Collections.Generic;

namespace Requirement6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of vehicles");
            int n = int.Parse(Console.ReadLine());

            List<Vehicle> vehicleList = new List<Vehicle>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Vehicle v = Vehicle.CreateVehicle(input);
                vehicleList.Add(v);
            }

            SortedDictionary<string, int> count =
                Vehicle.TypeWiseCount(vehicleList);

            Console.WriteLine("{0,-15} {1}", "Type", "No. of Vehicles");

            foreach (var item in count)
            {
                Console.WriteLine("{0,-15} {1}", item.Key, item.Value);
            }
        }
    }
}
