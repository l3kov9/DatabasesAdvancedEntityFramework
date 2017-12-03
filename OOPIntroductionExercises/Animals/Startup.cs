using Animals.Models;
using System;

namespace Animals
{
    public class Startup
    {
        public static void Main()
        {
            var animal = new Dog("pesho", 22, "Male");
            Console.WriteLine(animal.ProduceSound());
        }
    }
}
