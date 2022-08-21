using System;

namespace Persons
{
    internal class Student : Person
    {
        private double Gpa { get; }
        
        public Student(string firstName, string lastName, string address, int id, double gpa)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Id = id;
            Gpa = gpa;
        }

        public override void Display()
        {
            Console.WriteLine($"ID: {Id} - {FirstName} {LastName}, GPA: {Gpa}, Address: {Address}");
        }
    }
}
