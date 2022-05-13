using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight, int foodEaten)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
        }

        public string Name { get;protected set; }
        public double Weight { get;protected set; }
        public int FoodEaten { get; protected set; }

        public virtual void Feed(string foodType)
        {

        }

        public abstract void ProducingSound();
        
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
