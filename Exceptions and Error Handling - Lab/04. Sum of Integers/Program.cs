using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _04._Sum_of_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = new List<int>();

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                var currentElement = input[i];
                int currentResult = 0;
                decimal testRsult = 0.0m;
                BigInteger testRsult2 = 0;

                try
                {
                    if (int.TryParse(currentElement, out currentResult))
                    {
                        result.Add(currentResult);
                        Console.WriteLine($"Element '{currentElement}' processed - current sum: {result.Sum()}");
                        continue;
                    }
                    if (BigInteger.TryParse(currentElement, out testRsult2))
                    {
                        throw new OverflowException($"The element '{currentElement}' is out of range!");
                    }
                    else
                    {
                        throw new FormatException($"The element '{currentElement}' is in wrong format!");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine($"Element '{currentElement}' processed - current sum: {result.Sum()}");
            }

            Console.WriteLine($"The total sum of all integers is: {result.Sum()}");
        }
    }
}
