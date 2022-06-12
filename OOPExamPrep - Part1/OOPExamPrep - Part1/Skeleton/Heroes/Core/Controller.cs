using Heroes.Core.Contracts;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes => new HeroRepository();
        private WeaponRepository weapons => new WeaponRepository();

        public Controller()
        {
        }

       

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            throw new NotImplementedException();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            //IHero hero = null;

            //if (type == "Knight")
            //{
            //    hero = new Knight(name, health, armour);
            //    heroes.Add(hero);
            //    return $"Successfully added Sir {name} to the collection.";
            //}
            //else if (type == "Barbarian")
            //{
            //    hero = new Barbarian(name, health, armour);
            //    heroes.Add(hero);
            //    return $"Successfully added Barbarian {name} to the collection.";
            //}
            //else
            //{
            //    throw new InvalidOperationException("Invalid hero type.");
            //}
            return "";

        }

        public string CreateWeapon(string type, string name, int durability)
        {
            throw new NotImplementedException();
        }

        public string HeroReport()
        {
            throw new NotImplementedException();
        }

        public string StartBattle()
        {
            throw new NotImplementedException();
        }
    }
}
