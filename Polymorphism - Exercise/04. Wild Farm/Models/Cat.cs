using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        public override void ProducingSound()
        {
            Console.WriteLine("Meow");
        }

        public override void Feed(string foodType)
        {
            this.Weight += FoodEaten * 0.30;
        }
    }
}
