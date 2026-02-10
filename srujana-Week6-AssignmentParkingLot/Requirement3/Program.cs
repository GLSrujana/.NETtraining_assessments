using System;
using System.Text.RegularExpressions;

namespace Requirement3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the registration no. to be validated:");
            string registrationNo = Console.ReadLine();

            if (ValidateRegistrationNo(registrationNo))
                Console.WriteLine("Registration No. is valid");
            else
                Console.WriteLine("Registration No. is invalid");
        }

        public static bool ValidateRegistrationNo(string registrationNo)
        {
            if (string.IsNullOrWhiteSpace(registrationNo))
                return false;

            // Regex based on given rules
            string pattern = @"^[A-Z]{2}\s\d{1,2}\s[A-Z]{0,2}\s\d{1,4}$";

            return Regex.IsMatch(registrationNo, pattern);
        }
    }
}
