using System;

namespace Exercise12
{
    class Program
    {
        static void Main(string[] args)
        {
            TestPaper paper1 = new TestPaper("Maths", new string[] { "1A", "2C", "3D", "4A", "5A" }, "60%");
            TestPaper paper2 = new TestPaper("Chemistry", new string[] { "1C", "2C", "3D", "4A" }, "75%");
            TestPaper paper3 = new TestPaper("Computing", new string[] { "1D", "2C", "3C", "4B", "5D", "6C", "7A" }, "75%");

            Student student1 = new Student();
            Student student2 = new Student();

            student1.TestsTaken(); // ➞ "No tests taken"
            student1.TakeTest(paper1, new string[] { "1A", "2D", "3D", "4A", "5A" });
            student1.TestsTaken(); // ➞ "Maths: Passed! (80%)"

            student2.TakeTest(paper2, new string[] { "1C", "2D", "3A", "4C" });
            student2.TakeTest(paper3, new string[] { "1A", "2C", "3A", "4C", "5D", "6C", "7B" });
            student2.TestsTaken(); // ➞ "Chemistry: Failed! (25%)", "Computing: Failed! (43%)"

            Console.ReadKey();
        }
    }
}
