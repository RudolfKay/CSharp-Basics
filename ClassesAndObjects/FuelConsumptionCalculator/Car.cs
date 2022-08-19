namespace FuelConsumptionCalculator
{
    public class Car
    {
        private double _startKilometers;
        private double _endKilometers;
        private double _liters;

        public Car(double startOdo)
        {
            _startKilometers = startOdo;
        }

        public double CalculateConsumption()
        {
            return _liters / (_endKilometers - _startKilometers);
        }

        private double ConsumptionPer100Km()
        {
            return CalculateConsumption() * 100;
        }

        public string GasHog()
        {
            return ConsumptionPer100Km() > 15 ? "Yes" : "No";
        }

        public string EconomyCar()
        {
            return ConsumptionPer100Km() < 5 ? "Yes" : "No";
        }

        public void FillUp(int mileage, double liters)
        {
            _endKilometers = mileage;
            _liters = liters;
        }
    }
}
