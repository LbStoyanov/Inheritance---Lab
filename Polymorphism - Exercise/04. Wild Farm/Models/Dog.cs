using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten, livingRegion)
        {
        }
        public override void ProducingSound()
        {
            Console.WriteLine("Woof!");
        }

        public override string ToString()
        {
            return base.ToString();
        }
        public override void Feed(string foodType)
        {
            if (foodType != "Meat")
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {foodType}!");
                FoodEaten = 0;
            }
            this.Weight += FoodEaten * 0.40;

        }
    }
}
