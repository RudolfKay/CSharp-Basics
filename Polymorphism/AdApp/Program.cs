using System;

namespace AdApp
{
    class Program
    {
        private static void Main(string[] args)
        {
            var c = new Campaign("AdFest3000");

            c.AddAdvert(new Advert(1000));
            c.AddAdvert(new Hoarding(500, 7, 200, true));
            c.AddAdvert(new NewspaperAd(0, 30, 20));
            c.AddAdvert(new TVAd(50000, 1000, 30, true));
            c.AddAdvert(new Poster(10, 1920, 1280, 50, 1));

            Console.WriteLine(c.ToString());
            c.PrintReceipt();

            Console.ReadKey();
        }
    }
}