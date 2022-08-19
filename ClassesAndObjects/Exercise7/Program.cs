using System;
using System.Globalization;

namespace Exercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How much money is in the account?: ");
            decimal startBalance = Convert.ToDecimal(Console.ReadLine());
            SavingsAccount mySavings = new SavingsAccount(startBalance);

            Console.Write("Enter the annual interest rate: ");
            decimal annualInterest = Convert.ToDecimal(Console.ReadLine());
            mySavings.AnnualInterest(annualInterest);

            Console.Write("How long has the account been opened? ");
            int accountAge = Convert.ToInt32(Console.ReadLine());

            Console.ReadKey();
            Console.Clear();

            decimal totalDeposited = 0;
            decimal totalWithdrawn = 0;

            for (int i = 1; i <= accountAge; i++)
            {
                Console.WriteLine($"Enter amount deposited for month {i}: ");
                decimal deposit = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine($"Enter amount withdrawn for {i}: ");
                decimal withdrawal = Convert.ToDecimal(Console.ReadLine());

                mySavings.Deposit(deposit);
                mySavings.Withdraw(withdrawal);
                mySavings.AddMonthlyInterest();

                totalDeposited += deposit;
                totalWithdrawn += withdrawal;

                Console.Clear();
            }

            CultureInfo us = new CultureInfo("en-US");

            Console.WriteLine($"Total deposited: {totalDeposited.ToString("C", us)}");
            Console.WriteLine($"Total withdrawn: {totalWithdrawn.ToString("C", us)}");
            Console.WriteLine($"Interest earned: {mySavings.GetInterest().ToString("C", us)}");
            Console.WriteLine($"Ending balance: {mySavings.GetBalance().ToString("C", us)}");

            Console.ReadKey();
        }
    }
}
