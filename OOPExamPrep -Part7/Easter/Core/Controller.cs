using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        BunnyRepository bunnies;
        EggRepository eggs;
        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType != "HappyBunny" && bunnyType != "SleepyBunny")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            Bunny bunny = null;

            if (bunnyName == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyName == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }

            this.bunnies.Add(bunny);

            return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            if (!bunnies.Models.Any(x => x.Name == bunnyName))
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            Dye dye = new Dye(power);

            var bunny = bunnies.Models.FirstOrDefault(x => x.Name == bunnyName);
            bunny.AddDye(dye);

            return String.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            Egg egg = new Egg(eggName, energyRequired);
            this.eggs.Add(egg);

            return String.Format(OutputMessages.EggAdded, eggName);

        }

        public string ColorEgg(string eggName)
        {
            var coloringBunnies = bunnies.Models.Select(x => x.Energy >= 50).ToList();

            if (coloringBunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            Egg egg = (Egg)eggs.FindByName(eggName);
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
