using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndTeachers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] classes = { "English III" , "Pre-calculus" , "Music Theory" , "Biotechnology" , "Principles of Technology I" ,
                "Latin II" , "AP US History" , "Business Computer Information Systems" };

            string[] teachers = { "Ms. Lapan" , "Mrs. Gideon" , "Mr. Davis" , "Ms. Palmer" , "Ms. Garcia" , 
                "Mrs. Barnett" , "Ms. Johannessen" , "Mr. James" };

            int courseWidth = 37;
            int teacherWidth = 15;
            
            Dictionary<string, string> classAndTeacher = new Dictionary<string, string>();
            for (int i = 0; i < classes.Length; i++)
            {
                classAndTeacher.Add(classes[i], teachers[i]);
            }

            string table = $"+-----{string.Concat(Enumerable.Repeat('-', courseWidth + teacherWidth))}----+\n";
            int count = 0;

            foreach (string classKey in classAndTeacher.Keys)
            {
                count += 1;
                string thisTeacher = classAndTeacher[classKey];
                table += $"| {count} | {string.Concat(Enumerable.Repeat(' ', courseWidth - classKey.Length))}{classKey}" +
                                  $" | {string.Concat(Enumerable.Repeat(' ', teacherWidth - thisTeacher.Length))}{thisTeacher}" +
                                  $" |\n";
            }
            
            table += $"+-----{string.Concat(Enumerable.Repeat('-', courseWidth + teacherWidth))}----+";
            Console.WriteLine(table);
            Console.ReadKey();
        }
    }
}
