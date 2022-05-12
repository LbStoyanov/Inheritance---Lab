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
            double windgSize = 10;

            Owl owl = new Owl(name,weight,foodEaten,windgSize);
            
            //Console.WriteLine(owl.FoodEaten);

            string foodType = "Cheese";

            owl.Feed(foodType);

        }
    }
}
