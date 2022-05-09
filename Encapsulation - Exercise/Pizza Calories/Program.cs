using System;

namespace EncapsulationExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaInput = Console.ReadLine().Split(' ');

            string pizzaName = pizzaInput[1];

            string[] doughInput = Console.ReadLine().Split(' ');
           
            string flourType = doughInput[1];
            string backingTechnique = doughInput[2];
            int doughWeight = int.Parse(doughInput[3]);

            try
            {
                Dough dough = new Dough(flourType, backingTechnique, doughWeight);

                Pizza pizza = new Pizza(pizzaName, dough);

                string input;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = input.Split();

                    string toppingType = toppingInfo[1];
                    int toppingWeight = int.Parse(toppingInfo[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);
                }

             

                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
