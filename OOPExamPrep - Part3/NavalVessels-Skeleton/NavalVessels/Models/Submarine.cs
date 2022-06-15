using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, 200)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode { get; }

        public void ToggleSubmergeMode()
        {
            throw new NotImplementedException();
        }

        public override void RepairVessel()
        {
            base.RepairVessel();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
