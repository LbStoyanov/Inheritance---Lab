using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Owl : Bird
    {

        public Owl(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void ProducingSound()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override void Feed(string foodType)
        {
            if (foodType != "Meat")
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {foodType}!");
                FoodEaten = 0;
                return;
            }

            this.Weight += FoodEaten * 0.25;
        }
    }
}
