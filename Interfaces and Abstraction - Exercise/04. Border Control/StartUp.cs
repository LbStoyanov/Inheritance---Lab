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
            List<string> allBirthdates = new List<string>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] splittedInput = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);

                if (splittedInput[0] == "Citizen")
                {
                    string personName = splittedInput[1];
                    string age = splittedInput[2];
                    string personId = splittedInput[3];
                    string birthdate = splittedInput[4];
                    allBirthdates.Add(birthdate);
                }
                if(splittedInput[0] == "Robot")
                {
                    string model = splittedInput[0];
                    string robotId = splittedInput[1];
                }
                if(splittedInput[0] == "Pet")
                {
                    string petName = splittedInput[1];
                    string petBirthdate = splittedInput[2];
                    allBirthdates.Add(petBirthdate);
                }
            }

            string specificYear = Console.ReadLine();
            

            foreach (var birthdate in allBirthdates)
            {
                string yearToBeCompared = ExtractYearToCompare(birthdate);

                if (yearToBeCompared == specificYear)
                {
                    Console.WriteLine(birthdate);
                }
            }
           
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
