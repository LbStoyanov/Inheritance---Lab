using System;
using System.Linq;

namespace EncapsulationExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            string commands;

            while ((commands = Console.ReadLine()) != "END")
            {
                string[] splittedCommands = commands.Split(";");
                string action = splittedCommands[0];
                string teamName = splittedCommands[1];
                string playerName = splittedCommands[2];
                var stats = splittedCommands.Skip(3).ToList();



                Console.WriteLine();
            }
        }
    }
}
