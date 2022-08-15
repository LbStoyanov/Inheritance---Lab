using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.Planets
{
    public  class Planet : IPlanet
    {
        private string name;
        private double budget;
        private List<IMilitaryUnit> army;
        private List<IWeapon> weapons;
        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.army = new List<IMilitaryUnit>();
            this.weapons = new List<IWeapon>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                this.name = value;

            }
        }

        public double Budget
        {
            get => this.budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                this.budget = value;

            }
        }

        public double MilitaryPower => this.CalculateMilitaryPower();
        public IReadOnlyCollection<IMilitaryUnit> Army => this.army.AsReadOnly();
        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.AsReadOnly();
        public void AddUnit(IMilitaryUnit unit)
        {
            this.army.Add(unit);
        }

        

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.Add(weapon);
        }

        public void TrainArmy()
        {
            foreach (var force in this.army)
            {
                force.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (this.Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            this.Budget -= amount;
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public string PlanetInfo()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Planet: {this.Name}");
            result.AppendLine($"--Budget: {this.Budget} billion QUID");

            if (this.army.Count == 0)
            {
                result.AppendLine("--Forces: No units");
            }
            else
            {
                result.AppendLine($"--Forces: {string.Join(", ",this.army.Select(x => x.GetType().Name))}");
            }

            if (this.weapons.Count == 0)
            {
                result.AppendLine("--Combat equipment: No weapons");
            }
            else
            {
                result.AppendLine($"--Forces: {string.Join(", ", this.weapons.Select(x => x.GetType().Name))}");
            }
            result.AppendLine($"--Military Power: {this.MilitaryPower}");

            return result.ToString().TrimEnd();
        }

        private double CalculateMilitaryPower()
        {
            double totalUnitEndurance = this.army.Select(x => x.EnduranceLevel).Sum();
            double totalWeaponDestructionLevel = this.weapons.Select(x => x.DestructionLevel).Sum();
            double totalAmount = totalUnitEndurance + totalWeaponDestructionLevel;

            if (this.army.Any(x=> x.GetType().Name == "AnonymousImpactUnit"))
            {
                totalAmount += totalAmount * 0.30;
            }
            if (this.weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
            {
                totalAmount += totalAmount * 0.45;
            }

            return Math.Round(totalAmount, 3);
        }
    }
}
