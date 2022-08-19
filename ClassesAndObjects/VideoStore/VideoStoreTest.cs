using System;

namespace VideoStore
{
    class VideoStoreTest
    {
        private const int _countOfMovies = 3;
        private static VideoStore _videoStore = new VideoStore();

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose the operation you want to perform ");
                Console.WriteLine("Choose 0 for EXIT");
                Console.WriteLine("Choose 1 to fill video store");
                Console.WriteLine("Choose 2 to rent video (as user)");
                Console.WriteLine("Choose 3 to return video (as user)");
                Console.WriteLine("Choose 4 to add a rating");
                Console.WriteLine("Choose 5 to list inventory");

                int n = Convert.ToByte(Console.ReadLine());

                switch (n)
                {
                    case 0:
                        return;
                    case 1:
                        FillVideoStore();
                        break;
                    case 2:
                        RentVideo();
                        break;
                    case 3:
                        ReturnVideo();
                        break;
                    case 4:
                        AddRating();
                        break;
                    case 5:
                        ListInventory();
                        break;
                    default:
                        return;
                }
            }
        }

        private static void ListInventory()
        {
            _videoStore.ListInventory();
        }

        private static void FillVideoStore()
        {
            for (var i = 0; i < _countOfMovies; i++)
            {
                Console.WriteLine("Enter movie name");
                string movieName = Console.ReadLine();

                Console.WriteLine("Enter rating");
                int rating = Convert.ToInt16(Console.ReadLine());

                _videoStore.AddVideo(movieName);
                _videoStore.TakeUsersRating(rating, movieName);
            }

            Console.Clear();
        }

        private static void RentVideo()
        {
            Console.WriteLine("Enter movie name");
            string movieName = Console.ReadLine();
            _videoStore.Checkout(movieName);

            Console.Clear();
        }

        private static void ReturnVideo()
        {
            Console.WriteLine("Enter movie name");
            string movieName = Console.ReadLine();
            _videoStore.ReturnVideo(movieName);

            Console.Clear();
        }

        private static void AddRating()
        {
            Console.WriteLine("Which of our movies do you wish to rate?");
            string movieName = Console.ReadLine();

            Console.WriteLine("Enter rating");
            int rating = Convert.ToInt16(Console.ReadLine());

            _videoStore.TakeUsersRating(rating, movieName);

            Console.Clear();
        }
    }
}
