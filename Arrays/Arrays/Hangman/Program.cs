using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        private static string _randomWord;
        private static string[] _wordToGuess;
        private static string _misses;
        private static char _currGuess;

        private static void Main(string[] args)
        {
            InitGame();
            DisplayHangman();
            PlayHangman();
        }

        private static void InitGame()
        {
            string[] wordList = { "maintenance", "efficiency", "assignment", "combination", "construction",
                "video", "series", "phone", "hospital", "reality", "petrified", "escalate", "obliterate" };
            Random random = new Random();

            _randomWord = wordList[random.Next(wordList.Length)];
            _wordToGuess = new string[_randomWord.Length];
            _misses = "";

            for (int i = 0; i < _wordToGuess.Length; i++)
            {
                _wordToGuess[i] = "_ ";
            }
        }

        private static void DisplayHangman()
        {
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine();
            Console.WriteLine($"Word: {string.Join("",_wordToGuess)}");
            Console.WriteLine();
            Console.WriteLine($"Misses: {_misses}");
            Console.WriteLine();
            Console.WriteLine($"Guess: {_currGuess}");
            Console.WriteLine();
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-");
        }

        private static void PlayHangman()
        {
            while (!GameWon() && !OutOfGuesses())
            {
                Console.WriteLine("Guess a letter:");
                var userChoice = Console.ReadLine();
                int intCheck = 0;

                while (string.IsNullOrEmpty(userChoice.ToString()) || userChoice.Length > 1 || int.TryParse(userChoice, out intCheck))
                {
                    Console.WriteLine("Input invalid!\nGuess a single letter: ");
                    userChoice = Console.ReadLine();
                }

                _currGuess = Char.Parse(userChoice);
                Console.Clear();

                if (_randomWord.Contains(_currGuess))
                {
                    for (int i = 0; i < _randomWord.Length; i++)
                    {
                        if (_randomWord[i].Equals(_currGuess))
                        {
                            _wordToGuess[i] = _currGuess.ToString()+" ";
                        }
                    }
                }
                else
                {
                    _misses += _currGuess;
                    Console.WriteLine("Sorry! That's a miss...");
                }

                DisplayHangman();
            }

            if (GameWon())
            {
                Console.WriteLine("Congrats! You got it!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You've run out of guesses.\nFeel free to restart!");
                Console.ReadKey();
            }
        }

        private static bool GameWon()
        {
            return !_wordToGuess.Contains("_ ") ;
        }

        private static bool OutOfGuesses()
        {
            return _misses.Length == _randomWord.Length + 2;
        }
    }
}
