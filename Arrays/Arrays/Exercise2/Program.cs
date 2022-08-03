using System;

namespace Exercise2
{
    class Program
    {
        private static void Main(string[] args)
        {
            int intCheck = 0;
            var sum = 0;

            Console.WriteLine("Please enter a min number");
            var minInput = Console.ReadLine();
            Console.WriteLine("Please enter a max number");
            var maxInput = Console.ReadLine();

            while ( !int.TryParse(minInput, out intCheck) || !int.TryParse(maxInput, out intCheck) || int.Parse(maxInput) < int.Parse(minInput))
            {
                Console.WriteLine("One or more inputs not valid! Max has to be more than Min. Try again!\nPlease enter a min number");
                minInput = Console.ReadLine();
                Console.WriteLine("Please enter a max number");
                maxInput = Console.ReadLine();
            }

            int maxInt = int.Parse(maxInput);
            int minInt = int.Parse(minInput);

            for (int i= minInt; i <= maxInt; i++)
            {
                sum += i;
            }

            Console.WriteLine("The sum is " + sum);
            Console.ReadKey();
        }
    }
}
