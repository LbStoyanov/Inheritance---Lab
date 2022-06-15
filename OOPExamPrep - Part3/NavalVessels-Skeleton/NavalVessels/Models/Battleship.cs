using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel,IBattleship
    {
        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, 300)
        {
            this.SonarMode = false;
        }

        public bool SonarMode { get; }
        public void ToggleSonarMode()
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
