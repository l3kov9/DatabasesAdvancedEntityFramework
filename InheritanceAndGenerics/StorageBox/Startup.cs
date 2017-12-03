namespace StorageBox
{
    public class Startup
    {
        public static void Main()
        {
                var box = new Box<int>();

                for (int i = 0; i < 11; i++)
                {
                    box.AddElement(i);
                }

                System.Console.WriteLine(box);
        }
    }
}
