using System;
using System.Collections.Generic;

namespace Exercise4
{
    class Movie
    {
        private string _title;
        private string _studio;
        private string _rating;

        public Movie(string title, string studio, string rating)
        {
            _title = title;
            _studio = studio;
            _rating = rating;
        }

        public Movie(string title, string studio)
        {
            _title = title;
            _studio = studio;
            _rating = "PG";
        }

        public Movie[] GetPG(Movie[] allMovies)
        {
            List<Movie> moviesPg = new List<Movie>();

            for (int i = 0; i < allMovies.Length; i++)
            {
                if (allMovies[i]._rating.Equals("PG"))
                {
                    moviesPg.Add(allMovies[i]);
                }
            }

            return moviesPg.ToArray();
        }

        public override string ToString()
        {
            return $"Title: {_title}, Studio: {_studio}, Rating: {_rating}";
        }
    }
}
