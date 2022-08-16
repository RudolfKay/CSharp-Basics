
namespace DaysNames
{
    class Program
    {
        public static void Main(string[] args)
        {
            DayOfWeek daysOfWeek = new DayOfWeek();

            foreach (var day in Enum.GetNames(typeof(DayOfWeek)))
            {
                Console.WriteLine(day);
            }

            Console.ReadKey();
        }
    }
}
