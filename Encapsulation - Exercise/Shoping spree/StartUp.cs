using System;
using System.Collections.Generic;
using System.Linq;

namespace EncapsulationExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string,Person> personsDict = new Dictionary<string, Person>();

            string[] personsInput = Console.ReadLine().Split(new char[] { '=', ';' },StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Product> productsDict = new Dictionary<string, Product>();

            string[] productsInput = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                for (int i = 1; i <= personsInput.Length; i += 2)
                {
                    string currentPersonName = personsInput[i - 1];
                    decimal currentMoney = decimal.Parse(personsInput[i]);
                    personsDict.Add(currentPersonName, new Person(currentPersonName, currentMoney));
                }

                for (int i = 1; i <= productsInput.Length; i += 2)
                {
                    string currentProductName = productsInput[i - 1];
                    decimal currentCost = decimal.Parse(productsInput[i]);
                    productsDict.Add(currentProductName, new Product(currentProductName, currentCost));
                }

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] splittedCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string personName = splittedCommand[0];
                    string productName = splittedCommand[1];

                    Person person = personsDict[personName];
                    Product product = productsDict[productName];

                    bool isAdded = person.AddProduct(product);

                    if (!isAdded)
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                }

                foreach (var (name,person) in personsDict)
                {
                    string products = person.Products.Count > 0
                        ? string.Join(", ", person.Products.Select(x => x.Name))
                        : "Nothing bought";

                    Console.WriteLine($"{name} - {products}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



        }
    }
}
