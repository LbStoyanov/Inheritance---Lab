using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Core.Contracts
{
    public class Controller : IController
    {
        private PlanetRepository planetRepository;
        public Controller()
        {
            this.planetRepository = new PlanetRepository();
        }
        public string CreatePlanet(string name, double budget)
        {
            if (this.planetRepository.Models.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            IPlanet planet = new Planet(name, budget);
            this.planetRepository.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            if (!this.planetRepository.Models.Any(x => x.Name == planetName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet,planetName));
            }

            IPlanet planet = this.planetRepository.Models.First(x => x.Name == planetName);

            if (unitTypeName != "AnonymousImpactUnit" && unitTypeName != "SpaceForces" && unitTypeName != "StormTroopers")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName,
                    planet.Name));
            }

            IMilitaryUnit militaryUnit = null;

            if (unitTypeName == "AnonymousImpactUnit")
            {
                militaryUnit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == "SpaceForces")
            {
                militaryUnit = new SpaceForces();
            }
            else 
            {
                militaryUnit = new StormTroopers();
            }
            planet.Spend(militaryUnit.Cost);
            planet.AddUnit(militaryUnit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);

        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (!this.planetRepository.Models.Any(x => x.Name == planetName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IPlanet planet = this.planetRepository.Models.First(x => x.Name == planetName);

            if (planet.Weapons.Any(x=> x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName,
                    planetName));
            }

            if (weaponTypeName != "BioChemicalWeapon" && weaponTypeName != "NuclearWeapon" && weaponTypeName != "SpaceMissiles")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            IWeapon weapon = null;

            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else 
            {
                weapon = new SpaceMissiles(destructionLevel);
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
           

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);

        }

        public string SpecializeForces(string planetName)
        {
            if (!this.planetRepository.Models.Any(x => x.Name == planetName))
            {
                return string.Format(OutputMessages.ExistingPlanet, planetName);
            }

            IPlanet planet = planetRepository.FindByName(planetName);

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.Spend(1.25);
            planet.TrainArmy();
            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planetRepository.FindByName(planetOne);
            IPlanet secondPlanet = planetRepository.FindByName(planetTwo);

            string result = String.Empty;

            if (firstPlanet.MilitaryPower.Equals(secondPlanet.MilitaryPower))
            {
                if (firstPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon")
                    && secondPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon")
                    || firstPlanet.Weapons.All(x => x.GetType().Name != "NuclearWeapon")
                    && secondPlanet.Weapons.All(x => x.GetType().Name != "NuclearWeapon"))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);

                    return OutputMessages.NoWinner;
                }
                if (firstPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    var loosingPlaneBudget = secondPlanet.Budget / 2;
                    firstPlanet.Profit(loosingPlaneBudget);
                    var allCost = secondPlanet.Army.Select(x => x.Cost).Sum() +
                                  secondPlanet.Weapons.Select(x => x.Price).Sum();
                    firstPlanet.Profit(allCost);
                    this.planetRepository.RemoveItem(secondPlanet.Name);
                    result = $"{firstPlanet.Name} destructed {secondPlanet.Name}!";
                }
                else if (secondPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                {
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    var loosingPlaneBudget = firstPlanet.Budget / 2;
                    secondPlanet.Profit(loosingPlaneBudget);
                    var allCost = firstPlanet.Army.Select(x => x.Cost).Sum() +
                                  firstPlanet.Weapons.Select(x => x.Price).Sum();
                    secondPlanet.Profit(allCost);
                    this.planetRepository.RemoveItem(firstPlanet.Name);
                    result = $"{secondPlanet.Name} destructed {firstPlanet.Name}!";
                }
            }
            else if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                var loosingPlaneBudget = secondPlanet.Budget / 2;
                firstPlanet.Profit(loosingPlaneBudget);
                var allCost = secondPlanet.Army.Select(x => x.Cost).Sum() +
                              secondPlanet.Weapons.Select(x => x.Price).Sum();
                firstPlanet.Profit(allCost);
                this.planetRepository.RemoveItem(secondPlanet.Name);
                result = $"{firstPlanet.Name} destructed {secondPlanet.Name}!";
            }
            else
            {
                secondPlanet.Spend(secondPlanet.Budget / 2);
                var loosingPlaneBudget = firstPlanet.Budget / 2;
                secondPlanet.Profit(loosingPlaneBudget);
                var allCost = firstPlanet.Army.Select(x => x.Cost).Sum() +
                              firstPlanet.Weapons.Select(x => x.Price).Sum();
                secondPlanet.Profit(allCost);
                this.planetRepository.RemoveItem(firstPlanet.Name);
                result = $"{secondPlanet.Name} destructed {firstPlanet.Name}!";
            }

            return result;
        }

        public string ForcesReport()
        {
            var orderedPlanets = this.planetRepository.Models.OrderByDescending(x => x.MilitaryPower)
                .ThenBy(x => x.Name);

            StringBuilder result = new StringBuilder();
            result.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in orderedPlanets)
            {
                result.AppendLine(planet.PlanetInfo());
            }

            return result.ToString().TrimEnd();
        }
    }
}
