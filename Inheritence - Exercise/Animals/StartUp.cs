using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            List<Animal> animals = new List<Animal>();

            string animalType;

            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] animalInfo = Console.ReadLine().Split(" ");
                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);

                if (age < 0)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                Animal animal = default;

                if (animalType == "Cat")
                {
                    animal = new Cat(name, age, animalInfo[2]);
                    //animals.Add(cat);
                }
                if (animalType == "Dog")
                {
                    string gender = animalInfo[2];
                    animal = new Dog(name, age, gender);
                    //animals.Add(dog);
                }
                if (animalType == "Frog")
                {
                    string gender = animalInfo[2];
                    animal = new Frog(name, age, gender);
                    //animals.Add(frog);
                }
                if (animalType == "Kitten")
                {
                    animal = new Kitten(name, age);
                    //animals.Add(kitten);
                }
                if (animalType == "Tomcat")
                {
                    animal = new Tomcat(name, age);  
                    //animals.Add(tomcat);
                }

                Console.WriteLine(animalType);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                animal.ProduceSound();

            }

        }
    }
}
