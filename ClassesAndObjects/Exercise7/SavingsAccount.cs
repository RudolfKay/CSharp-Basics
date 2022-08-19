using System;

namespace Exercise7
{
    class SavingsAccount
    {
        private decimal _balance;
        private decimal _annualInterestRate;
        private decimal _interestEarned;

        public SavingsAccount(decimal startingBalance)
        {
            _balance = startingBalance;
        }

        public void Deposit(decimal amount)
        {
            _balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            _balance -= amount;
        }

        public void AnnualInterest(decimal amount)
        {
            _interestEarned = 0;
            _annualInterestRate = amount;
        }

        public void AddMonthlyInterest()
        {
            decimal monthlyInterest = _balance * (_annualInterestRate / 12);
            _balance += monthlyInterest;
            _interestEarned += monthlyInterest;
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public decimal GetInterest()
        {
            return _interestEarned;
        }
    }
}
