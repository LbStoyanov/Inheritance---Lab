using System;
using System.Collections.Generic;
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
                try
                {
                    string[] commands = Console.ReadLine().Split();
                    string action = commands[0];

                    if (action == "Replace")
                    {
                        int index = int.Parse(commands[1]);
                        int element = int.Parse(commands[2]);

                        integers[index] = element;
                    }

                    if (action == "Show")
                    {
                        int index = int.Parse(commands[1]);

                        Console.WriteLine(integers[index]);
                    }

                    if (action == "Print")
                    {
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);

                        if (startIndex < 0 || endIndex > integers.Length - 1)
                        {
                            throw new IndexOutOfRangeException();
                        }
                        

                        List<int> resultList = new List<int>();

                        for (int i = 0; i < integers.Length; i++)
                        {
                            if (i >= startIndex && i <= endIndex)
                            {
                                resultList.Add(integers[i]);
                            }
                        }

                        Console.WriteLine(string.Join(", ",resultList));
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    exceptionsCounter++;
                    Console.WriteLine($"The index does not exist!");
                }
                catch (ArgumentOutOfRangeException)
                {
                    exceptionsCounter++;
                    Console.WriteLine($"The index does not exist!");
                }
                catch (FormatException)
                {
                    exceptionsCounter++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
            }

            Console.WriteLine(String.Join(", ",integers));
        }
    }
}
