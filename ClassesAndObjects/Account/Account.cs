using System.Globalization;

namespace Account
{
    class Account
    {
        private readonly CultureInfo _formatCulture;
        private string _name;
        private double _money;

        public Account(string name, double startingBalance, CultureInfo locale)
        {
            _formatCulture = locale;
            _name = name;
            _money = startingBalance;
        }

        public void Withdrawal(double amount)
        {
            _money -= amount;
        }

        public void Deposit(double amount)
        {
            _money += amount;
        }

        public string Balance()
        {
            return _money.ToString("C", _formatCulture);
        }

        public override string ToString()
        {
            
            return $"{_name}: {_money.ToString("C", _formatCulture)}";
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}
