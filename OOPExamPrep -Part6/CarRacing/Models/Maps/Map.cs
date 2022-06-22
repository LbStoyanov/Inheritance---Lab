using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            double racingBehaviorMultiplier = 0.0;

            string result = string.Empty;

            if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                racerTwo.Car.Drive();
            }
            else if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                racerOne.Car.Drive();
            }
            else if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {

            }

            return result.TrimEnd();
        }
    }
}
