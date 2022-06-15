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
        private List<string> attackerListOfTargets;

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

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets { get; }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;

            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }

            Targets.Add(target.Name);

        }

        public abstract void RepairVessel();
        

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Type: {this.GetType().Name}");
            result.AppendLine($"Armor thickness: {this.ArmorThickness}");
            result.AppendLine($"Main weapon caliber: {this.MainWeaponCaliber}");
            result.AppendLine($"Speed: {this.Speed} knots");
            result.AppendLine($"Speed: {this.Speed} knots");
            if (this.attackerListOfTargets.Count == 0)
            {
                result.AppendLine("Targets: None");
            }
            else
            {
                result.AppendLine($"Targets: {string.Join(", ",Targets)}");
            }

           return result.ToString().TrimEnd();
        }
    }
}
