using System;
using System.Globalization;

namespace Account
{
    class Program
    {
        private static void Main(string[] args)
        {
            CultureInfo enUS = new CultureInfo("en-US");

            Account A = new Account("A", 100, enUS);
            Account B = new Account("B", 0, enUS);
            Account C = new Account("C", 0, enUS);


            Console.WriteLine("Initial state");
            Console.WriteLine(A);
            Console.WriteLine(B);
            Console.WriteLine(C+"\n");

            Transfer(A,B,50);
            Transfer(B,C,25);

            Console.WriteLine("Final state");
            Console.WriteLine(A);
            Console.WriteLine(B);
            Console.WriteLine(C);

            Console.ReadKey();
        }

        public static void Transfer(Account from, Account to, double howMuch)
        {
            from.Withdrawal(howMuch);
            to.Deposit(howMuch);
        }
    }
}
