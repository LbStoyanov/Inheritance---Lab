using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        public override void ProducingSound()
        {
            Console.WriteLine("ROAR!!!");
        }

        public override void Feed(string foodType)
        {
            if (foodType != "Meat")
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {foodType}!");
                FoodEaten = 0;
                return;
            }
            this.Weight += FoodEaten * 1.00;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
