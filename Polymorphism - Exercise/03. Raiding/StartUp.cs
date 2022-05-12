using System;
using System.Collections.Generic;

namespace  PolymorphismEx

{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());

            List<IHero> raidGroup = new List<IHero>();

            for (int i = 0; i < numberOfHeroes; i++)
            {
                string currentName = Console.ReadLine();
                string currentType = Console.ReadLine();

                IHero currentHero = null;

                if (currentType != "Druid" && currentType != "Paladin" && currentType != "Rogue" && currentType != "Warrior")
                {
                    Console.WriteLine("Invalid hero!");
                }
                else
                {
                    currentHero = GetHeroType(raidGroup, currentName, currentType, currentHero);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int totalHerosPower = 0;

            foreach (var hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
                totalHerosPower += hero.UnleasheAbilityPower();
            }

            if (totalHerosPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat!");
            }
        }

        private static IHero GetHeroType(List<IHero> heroes, string currentName, string currentType, IHero currentHero)
        {
            if (currentType == "Druid")
            {
                currentHero = new Druid(currentName);
                heroes.Add(currentHero);
            }
            else if (currentType == "Paladin")
            {
                currentHero = new Paladin(currentName);
                heroes.Add(currentHero);
            }
            else if (currentType == "Rogue")
            {
                currentHero = new Rogue(currentName);
                heroes.Add(currentHero);
            }
            else if (currentType == "Warrior")
            {
                currentHero = new Warrior(currentName);
                heroes.Add(currentHero);
            }

            return currentHero;
        }
    }
}
