using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncapsulationExercise
{
    public class Player
    {
        private readonly List<string> stats = new List<string>
        {
            "endurance",
            "sprint",
            "dribble",
            "endurance",
            "shooting",
        };
        private string name;
        public Player(string name,List<int> stats)
        {
            Name = name;
            Stats = stats;
        }
        

        public List<int> Stats
        {
            get { return Stats; }
            private set
            {
                

                if (Stats.Any(x => x < 0 || x > 100))
                {

                    int index = Stats.FindIndex(x => x < 0 || x > 100);

                    throw new ArgumentException($"{stats[index]} should be between 0 and 100.");
                }
                Stats = value;
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

    }
}
