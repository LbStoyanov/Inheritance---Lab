using System;
using System.Collections.Generic;
using System.Linq;

namespace EncapsulationExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            string commands;

            try
            {

                while ((commands = Console.ReadLine()) != "END")
                {
                    string[] splittedCommands = commands.Split(";");
                    string action = splittedCommands[0];
                    string teamName = splittedCommands[1];

                    if (action == "Team")
                    {

                    }
                    if (action == "Add")
                    {
                        string playerName = splittedCommands[2];
                        var stats = splittedCommands.Skip(3).ToList();
                    }
                    if (action == "Remove")
                    {
                        string playerName = splittedCommands[2];
                    }
                    if (action == "Raiting")
                    {

                    }

                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            

           
        }
    }
}
