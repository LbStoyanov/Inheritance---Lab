using System;

namespace PolymorphismEx
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = "Peshko";
            double weight = 300;
            int foodEaten = 10;

            Bird bird = new Bird(name,weight,foodEaten);
            bird;
        }
    }
}
