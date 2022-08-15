using System;

namespace Exercise12
{
    public class TestPaper : ITestpaper
    {
        private readonly string[] _markScheme;
        private readonly string _subject;
        private readonly string _passingMark;

        public TestPaper(string subject, string[] markScheme, string passingMark)
        {
            _subject = subject;
            _markScheme = markScheme;
            _passingMark = passingMark;
        }

        public string[] MarkScheme()
        {
            return _markScheme;
        }

        public string Subject()
        {
            return _subject;
        }

        public string PassMark()
        {
            return _passingMark;
        }
    }
}
