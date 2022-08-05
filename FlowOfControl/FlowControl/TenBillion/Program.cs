using System;

namespace TenBillion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input an integer number less than ten billion: ");
            var input = Console.ReadLine();
            long intCheck = 0;

            if (long.TryParse(input, out intCheck))
            {
                long numericInput = long.Parse(input);

                if (numericInput < 0) 
                {
                    numericInput *= -1;
                    input = numericInput.ToString();
                }

                if (numericInput >= 1e10) 
                {
                    Console.WriteLine("Number is greater or equals 10,000,000,000!");
                } 
                else 
                {
                    int digits = 1;

                    if (input.Length > 1) 
                    {
                        digits = 2;
                    } 
                    if (input.Length > 2) 
                    {
                        digits = 3;
                    } 
                    if (input.Length > 3) 
                    {
                        digits = 4;
                    } 
                    if (input.Length > 4) 
                    {
                        digits = 5;
                    } 
                    if (input.Length > 5) 
                    {
                        digits = 6;
                    } 
                    if (input.Length > 6) 
                    {
                        digits = 7;
                    } 
                    if (input.Length > 7) 
                    {
                        digits = 8;
                    } 
                    if (input.Length > 8) 
                    {
                        digits = 9;
                    } 
                    else if (input.Length > 9) 
                    {
                        digits = 10;
                    }

                    Console.WriteLine("Number of digits in the number: " + digits);
                }
            } 
            else 
            {
                Console.WriteLine("The number is not a long");
            }
            
            Console.ReadKey();
        }
    }
}
