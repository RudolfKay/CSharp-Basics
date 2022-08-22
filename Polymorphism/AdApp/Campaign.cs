using System;
using System.Collections.Generic;
using System.Linq;

namespace AdApp
{
    public class Campaign
    {
        private List<Advert> _campaign;
        private string _campaignName;

        public Campaign(string name) 
        {
            _campaign = new List<Advert>();
            _campaignName = name;
        }

        public void AddAdvert(Advert a) 
        {
            _campaign.Add(a);
        }

        public int GetCost()
        {
            return _campaign.Sum(item => item.Cost());
        }

        public override string ToString()
        {
            return $"Advert Campaign: {_campaignName}\nTotal Cost = £{GetCost()}\n";
        }

        public void PrintReceipt()
        {
            foreach (Advert ad in _campaign)
            {
                Console.WriteLine(ad.ToString());
                Console.WriteLine($"Final Price: £{ad.Cost()}");
                Console.WriteLine("----------------------");
            }
        }
    }
}