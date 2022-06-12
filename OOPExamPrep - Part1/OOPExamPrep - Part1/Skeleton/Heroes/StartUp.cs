using Heroes.Core;
using Heroes.Core.Contracts;
using Heroes.Models;
using Heroes.Models.Contracts;
using System;

namespace Heroes
{
    public class StartUp
    {
        public static double Average(int a, int b)
        {
            return a + b / 2.0;
        }
        public static void Main()
        {

            Console.WriteLine(Average(2, 1));

            //IEngine engine = new Engine();
            //engine.Run();

            //IWeapon mace = new Mace("Axe",3);
            //IWeapon claymore = new Claymore("Axse",4);

            //Console.WriteLine(claymore.DoDamage());
            //Console.WriteLine(mace.DoDamage());
        }
    }
}
