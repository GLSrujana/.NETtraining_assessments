using Weekly_Assignment_5CL;
using System;

namespace Weekly_Assignment_5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //* Exercise-1
            int n, i;
            int term;

            Console.WriteLine("Enter number of matches:");
            n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Runs scored by Dhoni:");

            for (i = 1; i <= n; i++)
            {
                term = i * (i + 1) * (i - 1);
                Console.Write(term + " ");
            }


            //* Exercise-2
            double xa, ya, ra;
            double xb, yb, rb;

            Console.WriteLine("\nEnter center and radius of circle A (xa ya ra):");
            xa = Convert.ToDouble(Console.ReadLine());
            ya = Convert.ToDouble(Console.ReadLine());
            ra = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter center and radius of circle B (xb yb rb):");
            xb = Convert.ToDouble(Console.ReadLine());
            yb = Convert.ToDouble(Console.ReadLine());
            rb = Convert.ToDouble(Console.ReadLine());

            double d = Math.Sqrt((xb - xa) * (xb - xa) + (yb - ya) * (yb - ya));

            if (d + rb < ra)
            {
                Console.WriteLine("B is in A");
            }
            else if (d + ra < rb)
            {
                Console.WriteLine("A is in B");
            }
            else if (d < ra + rb && d > Math.Abs(ra - rb))
            {
                Console.WriteLine("A and B intersect");
            }
            else
            {
                Console.WriteLine("A and B do not intersect");
            }


            //* Exercise-3
            try
            {
                Console.WriteLine("Enter Basic Salary:");
                double basicSalary = Convert.ToDouble(Console.ReadLine());

                double netSalary = Class1.CalculateNetSalary(basicSalary);

                Console.WriteLine("Net Salary = " + netSalary);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();



            //* Exercise-4
            Console.Write("Enter Customer ID: ");
            int customerId = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Email ID: ");
            string email = Console.ReadLine();

            Console.Write("Enter Connection Type (Industrial/Business/Domestic/Agricultural): ");
            string connectionType = Console.ReadLine();

            Console.Write("Enter Previous Reading: ");
            int prevReading = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Current Reading: ");
            int currReading = Convert.ToInt32(Console.ReadLine());

            int unitsConsumed = currReading - prevReading;
            double energyCharge = 0;

            if (unitsConsumed <= 100)
                energyCharge = unitsConsumed * 1.5;
            else if (unitsConsumed <= 250)
                energyCharge = (100 * 1.5) + ((unitsConsumed - 100) * 2.5);
            else if (unitsConsumed <= 550)
                energyCharge = (100 * 1.5) + (150 * 2.5) + ((unitsConsumed - 250) * 4.5);
            else
                energyCharge = (100 * 1.5) + (150 * 2.5) + (300 * 4.5) + ((unitsConsumed - 550) * 7.5);

            double meterRent = 0;

            switch (connectionType.ToLower())
            {
                case "industrial":
                    meterRent = 2500;
                    break;
                case "business":
                    meterRent = 1500;
                    break;
                case "domestic":
                    meterRent = 1000;
                    break;
                case "agricultural":
                    meterRent = 0;
                    break;
                default:
                    Console.WriteLine("Invalid Connection Type");
                    return;
            }

            double totalAmount = energyCharge + meterRent;

            Console.WriteLine("\n==============================================");
            Console.WriteLine("              ELECTRICITY BILL                 ");
            Console.WriteLine("==============================================");
            Console.WriteLine($" Customer ID        : {customerId}");
            Console.WriteLine($" Customer Name      : {customerName}");
            Console.WriteLine($" Address            : {address}");
            Console.WriteLine($" Phone              : {phone}");
            Console.WriteLine($" Email              : {email}");
            Console.WriteLine($" Connection Type    : {connectionType}");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($" Previous Reading   : {prevReading}");
            Console.WriteLine($" Current Reading    : {currReading}");
            Console.WriteLine($" Units Consumed     : {unitsConsumed}");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($" Energy Charges     : ₹{energyCharge}");
            Console.WriteLine($" Meter Rent         : ₹{meterRent}");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($" TOTAL AMOUNT       : ₹{totalAmount}");
            Console.WriteLine("==============================================");

            Console.ReadLine();



            //* Exercise-5
            int weight;


            Console.WriteLine("Enter John's weight: ");
            weight = Convert.ToInt32(Console.ReadLine());


            if (weight < 0 || weight > 120)
            {
                Console.WriteLine("Invalid input");
            }

            else if (weight <= 48)
            {
                Console.WriteLine("light fly");
            }
            else if (weight <= 51)
            {
                Console.WriteLine("fly");
            }

            else if (weight <= 54)
            {
                Console.WriteLine("bantam");
            }
            else if (weight <= 57)
            {
                Console.WriteLine("feather");
            }
            else if (weight <= 60)
            {
                Console.WriteLine("light");
            }
            else if (weight <= 64)
            {
                Console.WriteLine("light welter");
            }
            else if (weight <= 69)
            {
                Console.WriteLine("welter");
            }
            else if (weight <= 75)
            {
                Console.WriteLine("light middle");
            }
            else if (weight <= 81)
            {
                Console.WriteLine("middle");
            }
            else if (weight <= 91)
            {
                Console.WriteLine("light heavy");
            }
            else
            {
                Console.WriteLine("heavy");
            }
            Console.ReadLine();
        }
    }
}
