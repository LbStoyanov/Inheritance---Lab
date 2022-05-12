using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class FactoryHeroes
    {
        public static Hero CreateHero(string heroType, string heroName)
        {
            Hero baseHero;

            if (heroType == "Druid")
            {
                baseHero = new Druid(heroName);
            }
            else if (heroType == "Paladin")
            {
                baseHero = new Paladin(heroName);
            }
            else if (heroType == "Rogue")
            {
                baseHero = new Rogue(heroName);
            }
            else if (heroType == "Warrior")
            {
                baseHero = new Warrior(heroName);
            }
            else
            {
                throw new ArgumentException("Invalid hero!");
            }

            return baseHero;
        }
    }
}
