using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncapsulationExercise
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
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

        public int Stats
            => players.Any()
            ? (int)Math.Round(this.players.Average(x => x.Stats))
            : 0;




        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public bool RemovePlayer(string name)
        {
            Player playerToRemove = players.FirstOrDefault(x => x.Name == name);
            return players.Remove(playerToRemove);
        }
    }
}
