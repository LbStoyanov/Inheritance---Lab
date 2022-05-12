﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, int foodEaten)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
        }

        public string Name { get;private set; }
        public double Weight { get; set; }
        public int FoodEaten { get; private set; }

        public virtual void Eat()
        {

        }
        public virtual void Feed(string foodType)
        {

        }

        public virtual void ProducingSound()
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
