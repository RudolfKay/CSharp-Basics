using System;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Benson";
            decimal startBalance = (decimal)17.50;
            BankAccount benben = new BankAccount(name, startBalance);
            string nameBalance = benben.ShowUserNameAndBalance();

            Console.WriteLine(nameBalance);

            Console.ReadKey();
        }
    }
}
