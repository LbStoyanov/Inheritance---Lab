using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
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
                result = String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                racerOne.Car.Drive();
                result = String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                result = OutputMessages.RaceCannotBeCompleted;
            }
            else
            {
                double racerOneChanceOfWinning = 0.0;
                double racerTwoChanceOfWinning = 0.0;

                if (racerOne.RacingBehavior == "strict")
                {
                    racingBehaviorMultiplier = 1.2;
                }
                else
                {
                    racingBehaviorMultiplier = 1.1;
                }

                racerOneChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehaviorMultiplier;

                if (racerTwo.RacingBehavior == "strict")
                {
                    racingBehaviorMultiplier = 1.2;
                }
                else
                {
                    racingBehaviorMultiplier = 1.1;
                }

                racerTwoChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingBehaviorMultiplier;

                if (racerOneChanceOfWinning > racerTwoChanceOfWinning)
                {
                    result = String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
                }
                else
                {
                    result = String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
                }
            }


            return result;
        }
    }
}
