using MathForms.Models;
using System;

namespace MathForms
{
    public class Startup
    {
        public static void Main()
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            try
            {
                var box = new Box(length, width, height);

                Console.WriteLine($"Surface - {box.GetSurface()}");
                Console.WriteLine($"Volume - {box.GetVolume()}");
                Console.WriteLine($"Area - {box.GetArea()}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
