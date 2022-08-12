using System;
using System.Collections.Generic;

namespace VideoStore
{
    class VideoStore
    {
        private List<Video> _videos;

        public VideoStore()
        {
            _videos = new List<Video>();
        }

        public void AddVideo(string title)
        {
            _videos.Add(new Video(title));
        }
        
        public void Checkout(string title)
        {
            foreach (Video v in _videos)
            {
                if (v.Available() && v.Title == title)
                {
                    v.BeingCheckedOut();
                }
            }
        }

        public void ReturnVideo(string title)
        {
            foreach (Video v in _videos)
            {
                if (!v.Available() && v.Title == title)
                {
                    v.BeingReturned();
                }
            }
        }

        public void TakeUsersRating(double rating, string title)
        {
            foreach (Video v in _videos)
            {
                if (v.Title == title)
                {
                    v.ReceivingRating(rating);
                }
            }
        }

        public void ListInventory()
        {
            foreach (Video v in _videos)
            {
                Console.WriteLine(v.ToString());
            }
        }
    }
}
