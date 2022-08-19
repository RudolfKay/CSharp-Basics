using System.Collections.Generic;

namespace VideoStore
{
    class Video
    {
        private string _title;
        private double _rating;
        private int _ratingCount;
        private double _numOfLikes;
        private bool _isInStock;

        public Video(string title)
        {
            _title = title;
            _rating = 0.0;
            _ratingCount = 0;
            _isInStock = true;
            _numOfLikes = 0.0;
        }

        public void BeingCheckedOut()
        {
            _isInStock = false;
        }

        public void BeingReturned()
        {
            _isInStock = true;
        }

        public void ReceivingRating(double rating)
        {
            _rating += rating;
            _ratingCount += 1;
            
            if (rating >= 3.0)
            {
                _numOfLikes += 1;
            }
        }

        public double AverageRating()
        {
            return _rating / _ratingCount;
        }

        public double PercentOfLikes()
        {
            return (_numOfLikes / _ratingCount) * 100;
        }

        public bool Available()
        {
            return _isInStock;
        }

        public string Title => _title;

        public override string ToString()
        {
            return $"{Title} || Rating: {AverageRating()} || In Store: {Available()} || \"Like\" Percentage: {(int)PercentOfLikes()}";
        }
    }
}
