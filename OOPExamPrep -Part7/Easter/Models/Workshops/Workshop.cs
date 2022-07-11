using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            //This is only possible, if the bunny has energy and an dye that isn't finished.
            if (bunny.Energy > 0 && bunny.Dyes.Any(x => x.Power > 0))
            {


                foreach (var dye in bunny.Dyes)
                {

                    bunny.Work();
                    dye.Use();
                    egg.GetColored();

                    if (bunny.Energy < 0)
                    {
                        break;
                    }
                }

                if (egg.IsDone())
                {

                }

            }
        }
    }
}
