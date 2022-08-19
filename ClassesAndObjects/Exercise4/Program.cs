using System;
using System.Collections.Generic;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie test1 = new Movie("Casino Royale", "Eon Productions", "PG­13");
            Movie test2 = new Movie("Glass", "Buena Vista International", "PG­13");
            Movie test3 = new Movie("Spider-Man: Into the Spider-Verse", "Columbia Pictures", "PG");

            List<Movie> allMovies = new List<Movie>();
            allMovies.Add(test1);
            allMovies.Add(test2);
            allMovies.Add(test3);

            Movie[] pgMovies = test1.GetPG(allMovies.ToArray());

            foreach (Movie mov in pgMovies)
            {
                Console.WriteLine(mov.ToString());
            }

            Console.ReadKey();
        }
    }
}
