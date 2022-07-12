using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
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
        private int coloredEggs;
        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
            this.coloredEggs = 0;
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType != "HappyBunny" && bunnyType != "SleepyBunny")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            //IBunny bunny = null;

            if (bunnyType == "HappyBunny")
            {
                HappyBunny happyBunny = new HappyBunny(bunnyName);
                this.bunnies.Add(happyBunny);
                //bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                SleepyBunny sleepyBunny = new SleepyBunny(bunnyName);
                this.bunnies.Add(sleepyBunny);
                //bunny = new SleepyBunny(bunnyName);
            }

            //this.bunnies.Add(bunny);

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
            var coloringBunnies = bunnies.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy);

            //var result = string.Empty;

            if (coloringBunnies == null)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            IEgg egg = eggs.FindByName(eggName);

            Workshop workshop = new Workshop();

            var bunnysForRemove = new List<IBunny>();

            foreach (var bunny in coloringBunnies)
            {
                workshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    bunnysForRemove.Add(bunny);
                }

                if (egg.IsDone())
                {
                    this.coloredEggs++;
                    break;
                }
            }

            if (egg.IsDone())
            {

                foreach (var bunny in bunnysForRemove)
                {
                    this.bunnies.Remove(bunny);
                }

                return String.Format(OutputMessages.EggIsDone, eggName);
            }

            return String.Format(OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{this.coloredEggs} eggs are done!");
            result.AppendLine("Bunnys info: ");

            foreach (var bunny in bunnies.Models)
            {
                result.AppendLine($"Name: {bunny.Name}");
                result.AppendLine($"Energy: {bunny.Energy}");

                var notFinishedDyes = bunny.Dyes.Where(x => x.IsFinished() == false);

                result.AppendLine($"Dyes: {notFinishedDyes.Count()} not finished");
            }

            return result.ToString().TrimEnd();
        }
    }
}
