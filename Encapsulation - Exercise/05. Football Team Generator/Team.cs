using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulationExercise
{
    public class Team
    {
        private string name;
        private List<Player> players;
        public Team(string name,List<Player> players)
        {
            Name = name;
            Players = players;
        }
        public List<Player> Players { get; set; }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public void AddPlayer(Player player)
        {

        }
        public void RemovePlayer(Player player)
        {

        }
    }
}
