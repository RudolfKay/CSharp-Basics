using System;
using System.Collections.Generic;

namespace Exercise12
{
    public class Student : IStudent
    {
        private readonly List<string> _testsTaken;

        public Student()
        {
            _testsTaken = new List<string>();
        }

        public string[] TestsTaken()
        {
            if (_testsTaken.Count < 1)
            {
                Console.WriteLine("No tests taken!");
            }
            foreach (string test in _testsTaken)
            {
                Console.WriteLine(test);
            }

            return _testsTaken.ToArray();
        }

        public void TakeTest(ITestpaper paper, string[] answers)
        {
            string subject = paper.Subject();
            string[] markScheme = paper.MarkScheme();
            string scoreToPass = paper.PassMark().Replace('%',' ').Trim();

            decimal numCorrect = 0;

            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i].Equals(markScheme[i]))
                {
                    numCorrect++;
                }
            }

            decimal score = (numCorrect / markScheme.Length) * 100;

            if (score >= int.Parse(scoreToPass))
            {
                _testsTaken.Add($"{subject}: Passed! {score:#}%");
            }
            else
            {
                _testsTaken.Add($"{subject}: Failed! {score:#}%");
            }
        }
    }
}
