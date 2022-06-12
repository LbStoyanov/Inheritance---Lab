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
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
        }

       

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            throw new NotImplementedException();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {


            IHero hero = null;

            if (type == "Knight")
            {
                hero = new Knight(name, health, armour);
            }
            else if (type == "Barbarian")
            {
                hero = new Barbarian(name, health, armour);
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            
          
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
