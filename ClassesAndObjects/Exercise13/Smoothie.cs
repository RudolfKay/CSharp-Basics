using System;
using System.Globalization;

namespace Exercise13
{
    public class Smoothie
    {
        private readonly string[] _ingredients;
        private string _name;
        private decimal _price;
        private decimal _cost;

        public Smoothie(string[] ingredients)
        {
            _ingredients = ingredients;
        }

        public string Ingredients => string.Join(", ", _ingredients);

        public string GetName()
        {
            Array.Sort(_ingredients);
            string name = "";

            for (int i = 0; i < _ingredients.Length; i++)
            {
                if (_ingredients[i].EndsWith("ies"))
                {
                    name += _ingredients[i].Replace("ies", "y")+" ";
                }
                else
                {
                    name += _ingredients[i]+" ";
                }
            }

            if (_ingredients.Length > 1)
            {
                name += $"Fusion";
            }
            else if (_ingredients.Length == 1)
            {
                name += $"Smoothie";
            }

            _name = name;

            return _name;
        }

        public string GetPrice()
        {
            CultureInfo ukCultureInfo = new CultureInfo("en-GB");

            decimal price = _cost + (_cost * (decimal)1.5);
            _price = price;

            return _price.ToString("C", ukCultureInfo);
        }

        public string GetCost()
        {
            CultureInfo ukCultureInfo = new CultureInfo("en-GB");
            decimal cost = 0;

            for (int i = 0; i < _ingredients.Length; i++)
            {
                string currentIngredient = _ingredients[i];

                switch (currentIngredient)
                {
                    case "Strawberries":
                        cost += (decimal)1.50;
                        continue;

                    case "Banana":
                        cost += (decimal)0.50;
                        continue;

                    case "Mango":
                        cost += (decimal)2.50;
                        continue;

                    case "Blueberries":
                    case "Raspberries":
                        cost += (decimal)1.00;
                        continue;

                    case "Apple":
                        cost += (decimal)1.75;
                        continue;

                    case "Pineapple":
                        cost += (decimal)3.50;
                        continue;

                    default:
                        continue;
                }
            }

            _cost = cost;

            return _cost.ToString("C", ukCultureInfo);
        }
    }
}
