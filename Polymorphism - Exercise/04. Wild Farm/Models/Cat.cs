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
            if (foodType != "Meat" && foodType != "Vegetable")
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {foodType}!");
                FoodEaten = 0;
                return;
            }
            this.Weight += FoodEaten * 0.30;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
