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
            List<string> allIds = new List<string>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] splittedInput = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);

                if (splittedInput.Length == 3)
                {
                    string personName = splittedInput[0];
                    string age = splittedInput[1];
                    string personId = splittedInput[2];
                    allIds.Add(personId);
                }
                else
                {
                    string model = splittedInput[0];
                    string robotId = splittedInput[1];
                    allIds.Add(robotId);
                }
            }

            string fakeIdLastDigits = Console.ReadLine();

            foreach (var id in allIds)
            {
                var currentLastDigits = ExtractLastDigits(id,fakeIdLastDigits);

                if (currentLastDigits == fakeIdLastDigits)
                {
                    Console.WriteLine(id);
                }
            }
        }

        private static string ExtractLastDigits(string id, string fakeIdLastDigits)
        {
            StringBuilder sb = new StringBuilder();
            int counter = fakeIdLastDigits.Length;

            for (int i = id.Length - 1; i >= 0; i--)
            {
                if (counter == 0)
                {
                    break;
                }
                sb.Append(id[i]);
                counter--;

            }
            StringBuilder result = new StringBuilder();

            for (int i = sb.Length - 1; i >= 0; i--)
            {
                result.Append(sb[i]);
            }
            return result.ToString();
            
        }
    }
}
