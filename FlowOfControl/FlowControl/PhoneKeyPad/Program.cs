using System;
using System.Linq;

namespace PhoneKeyPad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your choice of text:");
            string input = Console.ReadLine();

            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("ERROR: Input null or empty. Try again!\nEnter text:");
                input = Console.ReadLine();
            }

            input = input.ToUpper();
            string answer = "";
            string[] keyPad = { "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ" };
            char[] keyPadNum = { '2', '3', '4', '5', '6', '7', '8', '9'};

            for (int i = 0; i < input.Length; i++)
            {
                char thisChar = input[i];

                for (int buttonIndex = 0; buttonIndex < keyPad.Length; buttonIndex++)
                {
                    if (keyPad[buttonIndex].Contains(thisChar))
                    {
                        char thisNum = keyPadNum[buttonIndex];

                        switch (keyPad[buttonIndex].IndexOf(thisChar))
                        {
                            case 0:
                                answer += new string(thisNum, 1);
                                break;
                            case 1:
                                answer += new string(thisNum, 2);
                                break;
                            case 2:
                                answer += new string(thisNum, 3);
                                break;
                            case 3:
                                answer += new string(thisNum, 4);
                                break;
                            default:
                                Console.WriteLine("Character not found. Ignoring this character.");
                                break;
                        }
                    }
                }
            }

            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}
