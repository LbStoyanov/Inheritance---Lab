using System;
using System.Linq;

namespace _05._Play_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int exceptionsCounter = 0;

            while (exceptionsCounter < 3)
            {
                string[] commands = Console.ReadLine().Split();
                //1 2 3 4 5
                string action = commands[0];
                //Replace

                if (action == "Replace")
                {
                    int indexResult = 0;
                    int elementResult = 0;
                    string index = commands[1];
                    string element = commands[2];

                    //Replace 1 kur||2.5
                    if (!int.TryParse(index, out indexResult))
                    {
                        exceptionsCounter++;
                        throw new ArgumentException("The index does not exist!");
                    }

                    if (!int.TryParse(element,out elementResult))
                    {
                        exceptionsCounter++;
                        throw new ArgumentException("The variable is not in the correct format!");
                    }

                    integers[int.Parse(index)] = int.Parse(element);

                }
            }
        }
    }
}
