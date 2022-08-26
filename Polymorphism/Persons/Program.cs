using System;

namespace Persons
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Randy", "Marsh", "Someplace st. 6, South Park, Park County, Colorado", 69420, 2.6);
            Employee employee = new Employee("Billy Bob", "Thornton", "Sandwich Lane 3490, New Orleans, Louisiana", 12302, "Fisherman");
            Person person = new Person("Steve", "Harvey", "90210 Beverly Hills, California",90210);

            student.Display();
            employee.Display();
            person.Display();

            Console.ReadKey();
        }
    }
}