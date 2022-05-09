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
            var teams = new Dictionary<string, Team>();

            while ((commands = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] splittedCommands = commands.Split(";");
                    string action = splittedCommands[0];
                    string teamName = splittedCommands[1];


                    if (action == "Team")
                    {
                        Team team = new Team(teamName);
                        teams.Add(teamName, team);
                    }
                    if (action == "Add")
                    {
                        string playerName = splittedCommands[2];
                        int endurance = int.Parse(splittedCommands[3]);
                        int sprint = int.Parse(splittedCommands[4]);
                        int dribble = int.Parse(splittedCommands[5]);
                        int passing = int.Parse(splittedCommands[6]);
                        int shooting = int.Parse(splittedCommands[7]);

                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        teams[teamName].AddPlayer(player);
                    }
                    if (action == "Remove")
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        string playerName = splittedCommands[2];

                        bool isRemoved = teams[teamName].RemovePlayer(playerName);

                        if (!isRemoved)
                        {
                            Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                        }

                    }
                    if (action == "Rating")
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }
                        Console.WriteLine($"{teamName} - {teams[teamName].Stats}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

      
    }
}
