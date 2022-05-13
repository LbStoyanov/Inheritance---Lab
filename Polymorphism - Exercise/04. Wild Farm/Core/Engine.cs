using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Engine
    {
        public void Run()
        {
            HashSet<IAnimal> animals = new HashSet<IAnimal>();

            while (true)
            {
                string[] animalInformation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (animalInformation[0] == "End")
                {
                    break;
                }
                string[] foodInformation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string animalType = animalInformation[0];
                string name = animalInformation[1];
                double weight = double.Parse(animalInformation[2]);

                
                string foodType = foodInformation[0];
                int foodEaten = int.Parse(foodInformation[1]);

                IAnimal currentAnimal = null;

                
                if (animalType == "Owl")
                {
                    int wingSize = int.Parse(animalInformation[3]);
                    currentAnimal = new Owl(name, weight, foodEaten, wingSize);
                    currentAnimal.ProducingSound();
                    currentAnimal.Feed(foodType);
                }
                if (animalType == "Hen")
                {
                    int wingSize = int.Parse(animalInformation[3]);
                    currentAnimal = new Hen(name,weight,foodEaten,wingSize);
                    currentAnimal.ProducingSound();
                    currentAnimal.Feed(foodType);
                }
                if (animalType == "Mouse")
                {
                    string livingRegion = animalInformation[3];
                    currentAnimal = new Mouse(name,weight,foodEaten,livingRegion);
                    currentAnimal.ProducingSound();
                    currentAnimal.Feed(foodType);
                }
                if (animalType == "Dog")
                {
                    string livingRegion = animalInformation[3];
                    currentAnimal = new Dog(name, weight, foodEaten, livingRegion);
                    currentAnimal.ProducingSound();
                    currentAnimal.Feed(foodType);
                }
                if (animalType == "Cat")
                {
                    string livingRegion = animalInformation[3];
                    string breed = animalInformation[4];
                    currentAnimal = new Cat(name, weight, foodEaten, livingRegion,breed);
                    currentAnimal.ProducingSound();
                    currentAnimal.Feed(foodType);
                }
                if (animalType == "Tiger")
                {
                    string livingRegion = animalInformation[3];
                    string breed = animalInformation[4];
                    currentAnimal = new Tiger(name, weight, foodEaten, livingRegion, breed);
                    currentAnimal.ProducingSound();
                    currentAnimal.Feed(foodType);
                }

                animals.Add(currentAnimal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }

        }
    }
}
