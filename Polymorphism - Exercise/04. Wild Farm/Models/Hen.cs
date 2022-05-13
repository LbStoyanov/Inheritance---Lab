using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void ProducingSound()
        {
            Console.WriteLine("Cluck");
        }

        public override void Feed(string foodType)
        {
            this.Weight += FoodEaten * 0.35;
        }
    }
}
