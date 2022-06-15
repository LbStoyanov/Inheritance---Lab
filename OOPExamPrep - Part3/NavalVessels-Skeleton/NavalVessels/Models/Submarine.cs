using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode = false;
        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, 200)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode
        {
            get { return submergeMode; }
            private set
            {
                this.submergeMode = value;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode == false)
            {
                this.SubmergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.SubmergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            };
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < 20)
            {
                this.ArmorThickness = 200;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());

            if (this.SubmergeMode == false)
            {
                result.AppendLine($"Submerge mode: OFF");
            }
            else
            {
                result.AppendLine($"Submerge mode: ON");
            }

            return result.ToString().TrimEnd();
        }
    }
}
