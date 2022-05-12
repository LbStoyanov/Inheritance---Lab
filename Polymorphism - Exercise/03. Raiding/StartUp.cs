using System;
using System.Collections.Generic;
using System.Linq;

namespace  PolymorphismEx

{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IHero> raidGroup = new List<IHero>();

            int lines = int.Parse(Console.ReadLine());
            int counter = 0;
;
            while (lines != counter)
            {
                string heroType = Console.ReadLine();
                string name = Console.ReadLine();
               

                try
                {
                    var hero = FactoryHeroes.CreateHero(name, heroType);
                    raidGroup.Add(hero);
                    counter++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            double bossPower = double.Parse(Console.ReadLine());

            foreach (var hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int sum = raidGroup.Sum(h => h.Power);

            if (sum >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
