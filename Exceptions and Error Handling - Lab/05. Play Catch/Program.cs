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
                        int indexResult = 0;
                        int elementResult = 0;
                        string index = commands[1];
                        string element = commands[2];

                        if (!int.TryParse(index, out indexResult))
                        {
                            exceptionsCounter++;
                            throw new ArgumentException("The index does not exist!");
                        }

                        if (!int.TryParse(element, out elementResult))
                        {
                            exceptionsCounter++;
                            throw new ArgumentException("The variable is not in the correct format!");
                        }

                        if (int.Parse(index) < 0 || int.Parse(index) > integers.Length - 1)
                        {
                            exceptionsCounter++;
                            throw new ArgumentException("The index does not exist!");
                        }

                        integers[int.Parse(index)] = int.Parse(element);
                    }

                    if (action == "Show")
                    {
                        string index = commands[1];
                        int result = 0;

                        if (int.TryParse(index, out result))
                        {
                            if (result >= 0 && result <= integers.Length - 1)
                            {
                                Console.WriteLine(integers[result]);
                            }
                            else
                            {
                                exceptionsCounter++;
                                throw new ArgumentException("The index does not exist!");
                            }
                        }
                        else
                        {
                            exceptionsCounter++;
                            throw new ArgumentException("The variable is not in the correct format!");
                        }
                    }

                    if (action == "Print")
                    {
                        int startIndexResult = 0;
                        int endIndexResult = 0;
                        string startIndex = commands[1];
                        string endIndex = commands[2];

                        if (!int.TryParse(startIndex, out startIndexResult))
                        {
                            exceptionsCounter++;
                            throw new ArgumentException("The index does not exist!");
                        }

                        if (!int.TryParse(endIndex, out endIndexResult))
                        {
                            exceptionsCounter++;
                            throw new ArgumentException("The variable is not in the correct format!");
                        }

                        if (int.Parse(startIndex) < 0 || int.Parse(endIndex) > integers.Length - 1)
                        {
                            exceptionsCounter++;
                            throw new ArgumentException("The index does not exist!");
                        }

                        List<int> resultList = new List<int>();

                        for (int i = 0; i < integers.Length; i++)
                        {
                            if (i >= int.Parse(startIndex) && i <= int.Parse(endIndex))
                            {
                                resultList.Add(integers[i]);
                            }
                        }

                        Console.WriteLine(string.Join(", ",resultList));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(String.Join(", ",integers));
        }
    }
}
