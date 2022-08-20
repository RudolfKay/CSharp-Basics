using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Histogram
{
    class Program
    {
        private const string Path = "../../midtermscores.txt";
        private static Dictionary<string, int> _scoreDictionary;

        private static void Main(string[] args)
        {
            var readText = File.ReadAllLines(Path);
            string[] text = string.Join(" ", readText).Trim().Split(' ');

            BuildDictionary();
            Histogram(text);

            Console.ReadKey();
        }

        public static void BuildDictionary()
        {
            _scoreDictionary = new Dictionary<string, int>();

            for (int i = 0; i <= 10; i++)
            {
                _scoreDictionary.Add(i != 10 ? $"{i}0 - {i}9" : $"    {i}0", 0);
            }
        }

        public static void Histogram(string[] testScores)
        {
            foreach (var s in testScores)
            {
                int score = int.Parse(s);

                for (int i = 0; i < _scoreDictionary.Count; i++)
                {
                    string key = _scoreDictionary.ElementAt(i).Key;

                    if (i != 10)
                    {
                        string[] keyValues = key.Replace(" - ", " ").Split(' ');
                        int min = int.Parse(keyValues[0]);
                        int max = int.Parse(keyValues[1]);

                        if (score >= min && score < max)
                        {
                            _scoreDictionary[key] += 1;
                            break;
                        }
                    }
                    else
                    {
                        _scoreDictionary[key] += 1;
                    }
                }
            }

            foreach (string key in _scoreDictionary.Keys)
            {
                Console.WriteLine($"{key}: {string.Concat(Enumerable.Repeat('*', _scoreDictionary[key]))}");
            }
        }
    }
}
