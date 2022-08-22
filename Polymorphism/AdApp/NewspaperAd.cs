namespace AdApp
{
    public class NewspaperAd : Advert
    {
        private int _column;
        private int _rate;

        public NewspaperAd(int fee, int rate, int column) : base(fee)
        {
            _rate = rate;
            _column = column;
        }

        public override int Cost()
        {
            var fee = base.Cost();
            var columnPrice = (_rate * _column);

            return fee + columnPrice;
        }

        public override string ToString()
        {
            var result = base.ToString();
            result += $"\nType: Newspaper Ad\nRate: £{_rate} per Cm\nColumn size: {_column}cm\n";

            return result;
        }
    }
}