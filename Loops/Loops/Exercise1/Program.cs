﻿using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            string answer = "";

            for (int i = 1; i <= n; i++)
            {
                answer += $"{i} ";
            }

            Console.WriteLine($"The first 10 natural numbers are: {answer.Trim()}");
            Console.ReadKey();
        }
    }
}
