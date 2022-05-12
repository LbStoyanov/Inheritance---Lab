using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, int foodEaten,double wingSize) 
            : base(name, weight, foodEaten)
        {
            Wingsize = wingSize;
        }

        public double Wingsize { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Wingsize}, {this.Weight}, {this.FoodEaten}]";
        }
        public override void Feed(string foodType)
        {
           
        }
    }
}
