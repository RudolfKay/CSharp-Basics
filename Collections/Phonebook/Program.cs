using System;
using PhoneBook;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Please enter number: ");
            var number = Console.ReadLine();

            PhoneDirectory phoneDirectory = new PhoneDirectory();
            phoneDirectory.PutNumber(name, number);
            phoneDirectory.PutNumber("Frank","20506789");
            phoneDirectory.PutNumber("Judith", "20598479");
            phoneDirectory.PutNumber("Bob", "25498097");
            phoneDirectory.PutNumber("Steve", "67859042");
            phoneDirectory.PutNumber("Frank", "89796045");

            phoneDirectory.PrintDirectory();

            Console.ReadKey();
        }
    }
}
