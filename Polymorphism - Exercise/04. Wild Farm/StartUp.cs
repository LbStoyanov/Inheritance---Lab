using System;
using System.Collections.Generic;

namespace PolymorphismEx
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string name = "Tom";
            double animalWeight = 2.5;
            double windgSize = 30;

            string foodType = "Meat";
            int foodEaten = 5; 

            string name2 = "Chiki";
            double animalWeight2 = 2.5;
            double windgSize2 = 30;

            string foodType2 = "Meat";
            int foodEaten2 = 5;
            
            

            Owl owl = new Owl(name,animalWeight,foodEaten,windgSize);
            Hen hen = new Hen(name2,animalWeight2,foodEaten2,windgSize2);

            owl.Feed(foodType);
            hen.Feed(foodType);
            owl.ProducingSound();
            hen.ProducingSound();
            Console.WriteLine(owl.ToString());
            Console.WriteLine(hen.ToString());

        }
    }
}
