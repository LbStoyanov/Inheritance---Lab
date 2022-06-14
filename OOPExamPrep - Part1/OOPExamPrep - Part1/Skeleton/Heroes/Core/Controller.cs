using Heroes.Core.Contracts;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Weapons;
using Heroes.Models.Map;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

       

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (!heroes.Models.Any(x => x.Name == heroName))
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            if (!weapons.Models.Any(x => x.Name == weaponName))
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            IHero hero = heroes.Models.FirstOrDefault(x => x.Name == heroName);

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            IWeapon weapon = weapons.Models.FirstOrDefault(x => x.Name == weaponName);

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);

            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.Models.Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"The hero { name } already exists.");
            }

            if (type != "Knight" && type != "Barbarian")
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            IHero hero = null;

            string result = string.Empty;

            if (type == "Knight")
            {
                hero = new Knight(name, health, armour);
                heroes.Add(hero);
                result = $"Successfully added Sir {name} to the collection.";
            }
            else if (type == "Barbarian")
            {
                hero = new Barbarian(name, health, armour);
                heroes.Add(hero);
                result = $"Successfully added Barbarian {name} to the collection.";
            }
            
            return result;
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.Models.Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            if (type != "Mace" && type != "Claymore")
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            string result = string.Empty;

            IWeapon weapon = null;

            if (type == "Mace")
            {
                weapon = new Mace(name, durability);

                weapons.Add(weapon);
            }
            else if (type == "Barbarian")
            {
                weapon = new Claymore(name, durability);

                weapons.Add(weapon);
            }

            result = $"A {type.ToLower()} {name} is added to the collection.";

            return result;
        }

        public string HeroReport()
        {
            StringBuilder result = new StringBuilder();

            var orderedListOfHeroes = 
                heroes.Models.OrderBy(x => x.GetType().Name).ThenBy(x => x.Health).ThenBy(x => x.Name).ToList();

            foreach (var hero in orderedListOfHeroes)
            {
                result.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                result.AppendLine($"--Health: {hero.Health}");
                result.AppendLine($"--Armour: {hero.Armour }");
                if (hero.Weapon == null)
                {
                    result.AppendLine($"--Weapon: Unarmed");
                }
                else
                {
                    result.AppendLine($"--Weapon: {hero.Weapon.Name}");
                }
                
            }

            return result.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            IMap map = new Map();
            string result = map.Fight((ICollection<IHero>)heroes);
            return result;

        }
    }
}
