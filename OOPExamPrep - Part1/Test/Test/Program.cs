using System;
using System.Collections.Generic;
using System.Linq;

public class UniqueNumbers
{
    public static IEnumerable<int> FindUniqueNumbers(IEnumerable<int> numbers)
    {
        var list = new List<int>(numbers);
        var result = new List<int>();

        for (int i = 0; i < list.Count(); i++)
        {
            for (int j = 1; j < list.Count(); j++)
            {
                if (list[i] == list[j])
                {
                    continue;
                }

                result.Add(j);
            }
        }

        return result;
    }

    public static void Main(string[] args)
    {
        int[] numbers = new int[] { 1, 2, 1, 3 };
        foreach (var number in FindUniqueNumbers(numbers))
            Console.WriteLine(number);
    }
}