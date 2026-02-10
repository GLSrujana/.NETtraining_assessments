using System;

namespace Requirement2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Parking Lot Name:");
                string name = Console.ReadLine();

                ParkingLot parkingLot = new ParkingLot(name, null);

                while (true)
                {
                    Console.WriteLine("\n1. Add Vehicle");
                    Console.WriteLine("2. Remove Vehicle");
                    Console.WriteLine("3. Display Vehicles");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("Enter your choice:");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter vehicle details:");
                            string details = Console.ReadLine();
                            Vehicle vehicle = Vehicle.CreateVehicle(details);
                            if (vehicle != null)
                                parkingLot.AddVehicleToParkingLot(vehicle);
                            break;

                        case 2:
                            Console.WriteLine("Enter Registration Number:");
                            string regNo = Console.ReadLine();
                            if (parkingLot.RemoveVehicleFromParkingLot(regNo))
                                Console.WriteLine("Vehicle removed successfully");
                            else
                                Console.WriteLine("Vehicle not found");
                            break;

                        case 3:
                            parkingLot.DisplayVehicles();
                            break;

                        case 4:
                            Console.WriteLine("Thank you");
                            return;

                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
