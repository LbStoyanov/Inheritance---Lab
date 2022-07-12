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
            if (bunny.Energy > 0 && bunny.Dyes.Any(x => x.Power > 0))
            {

                foreach (var dye in bunny.Dyes)
                {

                    while (!dye.IsFinished() && !egg.IsDone() && bunny.Energy > 0)
                    {
                        bunny.Work();
                        dye.Use();
                        egg.GetColored();
                    }

                    if (egg.IsDone())
                    {
                        return;
                    }

                    if (bunny.Energy < 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
