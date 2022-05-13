using System;
using System.Collections.Generic;

namespace _02._Enter_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> finalNumbers = new List<int>();
            int startNumber = 1;
            int endNumber = 100;
            int currentNumber = 1;
            
            while (finalNumbers.Count < 10)
            {
                
                try
                {
                    string input = Console.ReadLine();
                    

                    if (int.TryParse(input, out currentNumber))
                    {
                        if (currentNumber <= startNumber || currentNumber > endNumber)
                        {
                            throw new ArgumentException($"Your number is not in range { startNumber } - 100!");
                        }
                        else
                        {
                            
                            finalNumbers.Add(currentNumber);
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Invalid Number!");
                    }

                    startNumber = currentNumber;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine(String.Join(", ",finalNumbers));

        }
    }
}
