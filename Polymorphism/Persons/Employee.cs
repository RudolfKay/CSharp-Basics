using System;

namespace Persons
{
    internal class Employee : Person
    {
        private string JobTitle { get; }

        public Employee(string firstName, string lastName, string address, int id, string jobTitle)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Id = id;
            JobTitle = jobTitle;
        }

        public override void Display()
        {
            Console.WriteLine($"ID: {Id} - {FirstName} {LastName}, Job Title: {JobTitle}, Address: {Address}");
        }
    }
}
