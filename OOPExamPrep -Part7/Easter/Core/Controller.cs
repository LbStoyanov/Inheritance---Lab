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
            var coloringBunnies = bunnies.Models.Where(x => x.Energy >= 50);

            if (coloringBunnies == null)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }



            IEgg egg = eggs.FindByName(eggName);

            Workshop workshop = new Workshop();

            List<IBunny> bunniesForRemove = new List<IBunny>();

            //isDone na qiceto kazva dali e boqdisano ili ne!!!

            foreach (var bunny in coloringBunnies)
            {
                //1.Vzimam zaeka
                //2.vzimam purvata boq na tozi zaek
                foreach (var dye in bunny.Dyes)
                {
                    //•	If a bunny’s energy becomes 0, remove it from the repository.
                   
                    while (!dye.IsFinished())
                    {
                        dye.Use();
                        bunny.Work();
                        egg.GetColored();

                        if (egg.IsDone())
                        {
                            this.coloredEggs++;

                            return String.Format(OutputMessages.EggIsDone,eggName);
                        }

                        if (bunny.Energy == 0)
                        {
                            bunniesForRemove.Add(bunny);
                            break;
                        }
                    }

                }
            }
            
            

            //•	The bunny starts coloring the egg. This is only possible,
            //if the bunny has energy and an dye that isn't finished.
            //•	At the same time the egg is getting colored, so call the GetColored() method for the egg. 
            //•	Keep working until the egg is done or the bunny has energy and dyes to use.
            //•	If at some point the power of the current dye reaches or drops below 0, meaning it is finished,
            //then the Bunny should take the next Dye from its collection, if it has any left.


            return String.Format(OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{this.coloredEggs} eggs are done!");
            result.AppendLine("Bunnies info:");

            foreach (var bunny in bunnies.Models)
            {
                result.AppendLine($"Name: {bunny.Name}");
                result.AppendLine($"Energy: {bunny.Energy}");

                result.AppendLine($"Dyes: {bunny.Dyes} not finished");
            }

            return result.ToString().TrimEnd();
        }
    }
}
