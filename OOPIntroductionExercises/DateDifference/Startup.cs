using System;

namespace DateDifference
{
    public class Startup
    {
        public static void Main()
        {
            var firstDate = DateTime.Parse(Console.ReadLine());
            var secondDate = DateTime.Parse(Console.ReadLine());

            var dateModifier = new DateModifier(firstDate, secondDate);

            Console.WriteLine(dateModifier.DifferenceInDays());
        }
    }
}
