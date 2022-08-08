using System;

namespace TicTacToe
{
    class Program
    {
        private static char[,] board = new char[3, 3];

        private static void Main(string[] args)
        {
            InitBoard();
            DisplayBoard();
            TicTacToe();
        }

        private static void InitBoard()
        {
            for (var r = 0; r < 3; r++)
            {
                for (var c = 0; c < 3; c++)
                    board[r, c] = ' ';
            }
        }

        private static void DisplayBoard()
        {
            Console.WriteLine("      0   1   2");
            Console.WriteLine("    #---+---+---#");
            Console.WriteLine("  0 | " + board[0, 0] + " | " + board[0, 1] + " | " + board[0, 2] +  " |");
            Console.WriteLine("    +---+---+---+");
            Console.WriteLine("  1 | " + board[1, 0] + " | " + board[1, 1] + " | " + board[1, 2] + " |");
            Console.WriteLine("    +---+---+---+");
            Console.WriteLine("  2 | " + board[2, 0] + " | " + board[2, 1] + " | " + board[2, 2] + " |");
            Console.WriteLine("    #---+---+---#");
        }

        private static void TicTacToe()
        {
            char prevPlayer = 'O';
            
            while (IsBoardFull() && !HasWon())
            {
                char currPlayer = prevPlayer == 'O' ? 'X' : 'O';
                int row = 0;
                int col = 0;

                Console.WriteLine($"Player {currPlayer}: Choose location separated by comma(row,column)");
                var userChoice = Console.ReadLine().Replace(",", "");

                Console.Clear();

                if (board[int.Parse(userChoice[0].ToString()), int.Parse(userChoice[1].ToString())].Equals(' '))
                {
                    row = int.Parse(userChoice[0].ToString());
                    col = int.Parse(userChoice[1].ToString());

                    board[row, col] = currPlayer;
                }
                else
                {
                    Console.WriteLine("Location unavailable. Pick another!");
                }

                DisplayBoard();
                prevPlayer = currPlayer;                
            }

            if (HasWon())
            {
                Console.WriteLine($"Congratulations, {prevPlayer} has won!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Board is full.\nIt's a tie!");
                Console.ReadKey();
            }
        }
        
        private static bool IsBoardFull()
        {
            for (var r = 0; r < 3; r++)
            {
                for (var c = 0; c < 3; c++)
                {
                    if (board[r,c].Equals(' '))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool HasWon()
        {
                    //check by Row
            return (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2] && board[0, 0] != ' ') ||
                   (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2] && board[1, 0] != ' ') ||
                   (board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2] && board[2, 0] != ' ') ||
                   //check by Column
                   (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0] && board[0, 0] != ' ') ||
                   (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1] && board[0, 1] != ' ') ||
                   (board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2] && board[0, 2] != ' ') ||
                   //check by Diagonal
                   (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != ' ') ||
                   (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != ' ');
        }
    }
}
