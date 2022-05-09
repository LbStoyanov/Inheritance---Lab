using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncapsulationExercise
{
    public class Player
    {
        private readonly List<string> statsDict = new List<string>
        {
            "Endurance",
            "Sprint",
            "Dribble",
            "Endurance",
            "Shooting",
        };
        private List<int> stats;
        private string name;
        public Player(string name,List<int> stats)
        {
            Name = name;
            Stats = stats;
        }
        

        public List<int> Stats
        {
            get { return stats; }
            private set
            {
                if (value.Any(x => x < 0 || x > 100))
                {

                    int index = value.FindIndex(x => x < 0 || x > 100);

                    throw new ArgumentException($"{statsDict[index]} should be between 0 and 100.");
                }
                stats = value;
            }
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        private  int OverallSkillRating()
            => Stats.Sum() / Stats.Count();
        

    }
}
