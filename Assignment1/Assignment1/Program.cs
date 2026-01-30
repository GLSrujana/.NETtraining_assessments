namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //* Arithmetic Operations
            int a = 18;
            int b = 6;

            int c = a + b;
            Console.WriteLine(c);

            c = a - b;
            Console.WriteLine(c);

            c = a * b;
            Console.WriteLine(c);

            c = a / b;
            Console.WriteLine(c);

            int d = (a + b) - 6 * (12 * 4) / 3 + 12;
            Console.WriteLine(d);



            //* Trying with double
            double x = 19;
            double y = 23;
            double z = 8;
            double res = (x + y) / z;
            Console.WriteLine(res);

            double third = 1.0 / 3.0;
            Console.WriteLine(third);

            //* Trying with decimals
            decimal min = decimal.MinValue;
            decimal max = decimal.MaxValue;
            Console.WriteLine(min);
            Console.WriteLine(max);

            //* Strings and Text
            string aFriend = "Kavya";
            Console.WriteLine(aFriend);

            Console.WriteLine("Hello " + aFriend);
            Console.WriteLine("Hello " + aFriend);

            string greeting = "      Hello World!       ";
            Console.WriteLine($"[{greeting}]");

            string trimmedGreeting = greeting.TrimStart();
            Console.WriteLine($"[{trimmedGreeting}]");

            trimmedGreeting = greeting.TrimEnd();
            Console.WriteLine($"[{trimmedGreeting}]");

            trimmedGreeting = greeting.Trim();
            Console.WriteLine($"[{trimmedGreeting}]");



            //* Swapping numbers
            int num1, num2, temp;

            Console.WriteLine("Enter first number:");
            num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            num2 = int.Parse(Console.ReadLine());

            temp = num1;
            num1 = num2;
            num2 = temp;

            Console.WriteLine("After swapping");
            Console.WriteLine($"First number: {num1}");
            Console.WriteLine($"Second number: {num2}");




        }
    }
}
