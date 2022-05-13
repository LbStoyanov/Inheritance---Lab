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
            this.Weight += FoodEaten * 1.00;
        }
    }
}
