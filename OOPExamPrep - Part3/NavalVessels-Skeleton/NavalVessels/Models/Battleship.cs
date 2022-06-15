using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel,IBattleship
    {
        
        private bool sonarMode = false;
        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, 300)
        {
        }

        public bool SonarMode
        {
            get { return sonarMode; }
            private set
            {
                this.sonarMode = value;
            }
        }
        public void ToggleSonarMode()
        {
            if (this.SonarMode == false)
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }

           

        }
        public override void RepairVessel()
        {
            if (this.ArmorThickness < 300)
            {
                this.ArmorThickness = 300;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());

            if (this.SonarMode == false)
            {
                result.AppendLine($"Sonar mode: OFF");
            }
            else
            {
                result.AppendLine($"Sonar mode: ON");
            }
            
            return result.ToString().TrimEnd();
        }
    }
}
