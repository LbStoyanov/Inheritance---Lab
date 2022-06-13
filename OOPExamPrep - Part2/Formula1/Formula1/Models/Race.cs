using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;
        private List<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            this.tookPlace = false;
            this.pilots = new List<IPilot>();
        }
        public string RaceName
        {
            get { return raceName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRaceName, value);
                }

                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get { return numberOfLaps; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidLapNumbers, value.ToString());
                }

                numberOfLaps = value;
            }
        }

        public bool TookPlace
        {
            get { return tookPlace; }
            set { tookPlace = value; }
        }

        public ICollection<IPilot> Pilots { get; }

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The {this.RaceName } race has:");
            sb.AppendLine($"Participants: {pilots.Count }");
            sb.AppendLine($"Number of laps: {numberOfLaps }");
            sb.AppendLine($"Took place: {tookPlace}");

            return sb.ToString().TrimEnd();

        }
    }
}
