using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncapsulationExercise
{
    public class Player
    {
        private readonly int endurance;
        private readonly int sprint;
        private readonly int dribble;
        private readonly int passing;
        private readonly int shooting;
        private string name;
        public Player(string name,int endurance,int sprint,int dribble,int passing,int shooting)
        {
            Name = name;
            ValidateStat("Endurance",endurance);
            ValidateStat("Sprint", sprint);
            ValidateStat("Dribble", dribble);
            ValidateStat("Passing", passing);
            ValidateStat("Shooting", shooting);
            this.endurance = endurance;
            this.sprint = sprint;
            this.dribble = dribble;
            this.passing = passing;
            this.shooting = shooting;
            
        }

        public double Stats
            => (this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5.00;
        
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

        private void ValidateStat(string name,int endurance)
        {
            if (endurance < 0 || endurance > 100)
            {
                throw new ArgumentException($"{name} should be between 0 and 100.");
            };
        }

    }
}
