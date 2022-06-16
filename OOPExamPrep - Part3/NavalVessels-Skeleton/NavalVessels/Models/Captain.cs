using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience = 0;
       
        

        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.Vessels = new List<IVessel>();
            
        }
        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }

                this.fullName = value;
            }
        }

        public int CombatExperience { get { return this.combatExperience; } }

        public ICollection<IVessel> Vessels { get; }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.combatExperience += 10;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");

            if (this.Vessels.Count > 0)
            {
                var submarines = Vessels.OfType<Submarine>();
                var battleships = Vessels.OfType<Battleship>();

                foreach (var submarine in submarines)
                {
                    result.AppendLine(submarine.ToString());
                    //result.AppendLine($"- {submarine.Name}");
                    //result.AppendLine($"Type: {submarine.GetType().Name}");
                    //result.AppendLine($"Armor thickness: {submarine.ArmorThickness}");
                    //result.AppendLine($"Main weapon caliber: {submarine.MainWeaponCaliber}");
                    //result.AppendLine($"Speed: {submarine.Speed} knots");

                    //if (submarine.Targets.Count > 0)
                    //{
                    //    result.AppendLine($"Targets: {string.Join(", ", submarine.Targets)}");
                    //}
                    //else
                    //{
                    //    result.AppendLine($"Targets: None");
                    //}

                    //if (submarine.SubmergeMode == false)
                    //{
                    //    result.AppendLine("Submerge mode: OFF");
                    //    continue;
                    //}

                    //result.AppendLine("Submerge mode: ON");

                }

                foreach (var battleship in battleships)
                {
                    result.AppendLine(battleship.ToString());
                    //result.AppendLine($"- {battleship.Name}");
                    //result.AppendLine($"Type: {battleship.GetType().Name}");
                    //result.AppendLine($"Armor thickness: {battleship.ArmorThickness}");
                    //result.AppendLine($"Main weapon caliber: {battleship.MainWeaponCaliber}");
                    //result.AppendLine($"Speed: {battleship.Speed} knots");
                    
                    //if (battleship.Targets.Count > 0)
                    //{
                    //    result.AppendLine($"Targets: {string.Join(", ", battleship.Targets)}");
                    //}
                    //else
                    //{
                    //    result.AppendLine($"Targets: None");
                    //}

                    //if (battleship.SonarMode == false)
                    //{
                    //    result.AppendLine("Sonar mode: OFF");
                    //    continue;
                    //}

                    //result.AppendLine("Sonar mode: ON");

                }
            }

            return result.ToString().TrimEnd();
        }
    }
}
