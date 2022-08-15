using System;

namespace Exercise12
{
    public interface IStudent
    {
        string[] TestsTaken();

        void TakeTest(ITestpaper paper, string[] answers);
    }
}
