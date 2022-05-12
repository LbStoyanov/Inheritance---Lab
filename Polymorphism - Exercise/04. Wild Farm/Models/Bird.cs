using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, int foodEaten,double wingSize) 
            : base(name, weight, foodEaten)
        {
            Wingsize = wingSize;
        }

        public double Wingsize { get; set; }
    }
}
