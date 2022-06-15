using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidVesselName);
                }

                this.name = value;
            }
        }

        public ICaptain Captain
        {
            get { return this.captain; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
                value = this.captain;
            }

        }
        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get;}

        public double Speed { get; }

        public ICollection<string> Targets { get; }

        public void Attack(IVessel target)
        {
            throw new NotImplementedException();
        }

        public virtual void RepairVessel()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {

           return base.ToString();
        }
    }
}
