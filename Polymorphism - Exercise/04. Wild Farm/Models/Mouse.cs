using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten, livingRegion)
        {
        }
        public override void ProducingSound()
        {
            Console.WriteLine("Squeak");
        }

        public override string ToString()
        {
            return base.ToString();
        }
        public override void Feed(string foodType)
        {
            if (foodType != "Vegetable" && foodType != "Fruit")
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {foodType}!");
                FoodEaten = 0;
            }
            this.Weight += FoodEaten * 0.10;

        }
    }
}
