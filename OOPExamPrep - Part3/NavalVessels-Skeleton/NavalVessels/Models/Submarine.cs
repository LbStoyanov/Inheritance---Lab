using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        public Submarine(string name, double mainWeaponCaliber, double speed, double armorThickness) 
            : base(name, mainWeaponCaliber, speed, armorThickness)
        {
        }

        public bool SubmergeMode => throw new NotImplementedException();

        public void ToggleSubmergeMode()
        {
            throw new NotImplementedException();
        }
    }
}
