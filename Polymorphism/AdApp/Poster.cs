using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdApp
{
    public class Poster : Advert
    {
        private int _width;
        private int _height;
        private int _amount;
        private int _costPerItem;

        public Poster(int fee, int width, int height, int amount, int costPerPoster) : base(fee)
        {
            _width = width;
            _height = height;
            _amount = amount;
            _costPerItem = costPerPoster;
        }

        public override int Cost()
        {
            var fee = base.Cost();
            var posterCost = _amount * _costPerItem;

            return fee + posterCost;
        }

        public override string ToString()
        {
            var result = base.ToString();
            result += $"\nType: Poster\nSize: {_width}x{_height}px\nCost: £{_costPerItem} per poster\nAmount: {_amount}\n";

            return result;
        }
    }
}
