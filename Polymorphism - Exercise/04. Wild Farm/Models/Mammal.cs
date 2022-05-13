using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, int foodEaten,string livingRegion) 
            : base(name, weight, foodEaten)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; protected set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
        public override void Feed(string foodType)
        {

        }
    }
}
