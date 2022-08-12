using System;

namespace BankAccount
{
    class BankAccount
    {
        private string _name;
        private decimal _balance;

        public BankAccount(string name, decimal startBalance)
        {
            _name = name;
            _balance = startBalance;
        }

        public string ShowUserNameAndBalance()
        {
            return _balance >= 0 ? $"{_name}, ${_balance:0.00}" : $"{_name}, -${Math.Abs(_balance):0.00}";
        }
    }
}
