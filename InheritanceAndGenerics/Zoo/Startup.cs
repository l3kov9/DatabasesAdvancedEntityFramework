namespace Zoo
{
    using System;
    using Zoo.Models;

    public class Startup
    {
        public static void Main()
        {
            var puppy = new Puppy();
            puppy.Bark();
            puppy.Eat();
            puppy.Weep();
        }
    }
}
