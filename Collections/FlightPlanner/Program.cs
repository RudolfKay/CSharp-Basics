using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Console = System.Console;


namespace FlightPlanner
{
    class Program
    {
        private const string Path = "../../flights.txt";
        private static Dictionary<string, List<string>> _flightMap = new Dictionary<string, List<string>>();
        private static List<string> _roundTrip = new List<string>();
        private static string _startingCity;

        private static void Main(string[] args)
        {
            var readText = File.ReadAllLines(Path);

            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("Display Flights: Enter 1");
            Console.WriteLine("Exit: Enter 0");

            var choice = Console.ReadLine();
            bool inputValid = new bool();

            while (!inputValid)
            {
                switch (choice)
                {
                    case "1":
                        DisplayFlights(readText);

                        Console.WriteLine("\nWhich city are you in?");
                        _startingCity = Console.ReadLine();
                        FlightPlanner(_startingCity);

                        inputValid = true;
                        break;

                    case "0":
                        inputValid = true;
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Selection invalid!\nPress 1 to display cities || Press 0 to exit...");
                        choice = Console.ReadLine();
                        Console.Clear();
                        continue;
                }
            }

            string roundTrip = string.Join(" -> ", _roundTrip).Trim('-', '>', ' ');

            if (!string.IsNullOrEmpty(roundTrip))
            {
                Console.WriteLine($"\nHome: {_startingCity}");
                Console.WriteLine($"Trip Summary: \n{_startingCity} -> {roundTrip} -> {_startingCity}");
            }
            Console.ReadKey();
        }

        public static void FlightPlanner(string flightFrom)
        {
            bool inputValid = new bool();

            while (!inputValid)
            {
                Console.Clear();

                if (_flightMap.ContainsKey(flightFrom))
                {
                    Console.WriteLine($"\nConnecting flights are:\n{string.Join(" | ", _flightMap[flightFrom]).Trim()}");
                    Console.WriteLine("\nChoose your destination! Type 'exit' to stay here and quit planning.");

                    var flightTo = Console.ReadLine();

                    if (flightTo.ToLower().Trim().Equals("exit"))
                    {
                        inputValid = true;
                    }
                    else if (flightTo.Equals(_startingCity))
                    {
                        Console.WriteLine("\nWelcome Home!\nThank you for flying with Scuffed Airlines!");
                        inputValid = true;
                    }
                    else
                    {
                        _roundTrip.Add(flightTo);
                        FlightPlanner(flightTo);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Where would you like to fly from? ");
                    flightFrom = Console.ReadLine();
                }
            }
        }

        public static void DisplayFlights(string[] flights)
        {
            foreach (var s in flights)
            {
                BuildMap(s);
                Console.WriteLine(s);
            }
        }

        public static void BuildMap(string flight)
        {
            var flightFromTo = flight.Replace(" -> ","-").Split('-');
            string departure = flightFromTo[0].Trim();
            string destination = flightFromTo[1].Trim();

            if (_flightMap.ContainsKey(departure))
            {
                _flightMap[departure].Add(destination);
            }
            else
            {
                _flightMap.Add(departure, new List<string>() { destination });
            }
        }
    }
}
