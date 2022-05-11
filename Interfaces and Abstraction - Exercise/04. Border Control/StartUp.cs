using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            List<string> citizenNames = new List<string>();
            List<string> rebelNames = new List<string>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string input = Console.ReadLine();
                string[] splittedInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = splittedInput[0];

                if (splittedInput.Length == 4)
                {
                    citizenNames.Add(name);
                }
                else
                {
                    rebelNames.Add(name);
                }
            }

            string names;
            int totalFood = 0;

            while ((names = Console.ReadLine()) != "End")
            {

                if (citizenNames.Contains(names))
                {
                    totalFood += 10; 
                }
                if (rebelNames.Contains(names))
                {
                    totalFood += 5;
                }
                
            }

            Console.WriteLine(totalFood);
        }

        private static string ExtractYearToCompare(string birthdate)
        {
            StringBuilder result = new StringBuilder();

            char[] birthdateArr = birthdate.ToCharArray();

            for (int i = 6; i < birthdateArr.Length; i++)
            {
                result.Append(birthdateArr[i]);
            }

            return result.ToString();
        }
    }
}
