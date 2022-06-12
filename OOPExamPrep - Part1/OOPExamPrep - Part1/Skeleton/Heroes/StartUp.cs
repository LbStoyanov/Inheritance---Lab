using Heroes.Core;
using Heroes.Core.Contracts;
using Heroes.Models;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;

namespace Heroes
{
    public class StartUp
    {
        public static void Main()
        {
            //IHero knight = new Knight("Peko",5,5);

            //HeroRepository heroRepo = new HeroRepository();

            //heroRepo.Add(knight);
            //heroRepo.Add(knight);

            //Console.WriteLine();


            IEngine engine = new Engine();
            engine.Run();

            //IWeapon mace = new Mace("Axe",3);
            //IWeapon claymore = new Claymore("Axse",4);

            //Console.WriteLine(claymore.DoDamage());
            //Console.WriteLine(mace.DoDamage());
        }
    }
}
