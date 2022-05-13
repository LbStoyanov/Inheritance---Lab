using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        public void Feed(string foodType);

        public void ProducingSound();
        public string ToString();
    }
}
