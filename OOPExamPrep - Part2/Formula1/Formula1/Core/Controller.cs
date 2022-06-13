using Formula1.Core.Contracts;
using Formula1.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Formula1.Utilities;
using Formula1.Models;
using Formula1.Models.Contracts;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository => new PilotRepository();
        private RaceRepository raceRepository => new RaceRepository();
        private FormulaOneCarRepository FormulaOneCarRepository => new FormulaOneCarRepository();
        public Controller()
        {
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (!FormulaOneCarRepository.Models.Any(c => c.Model == carModel))
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            var car = FormulaOneCarRepository.Models.FirstOrDefault(c => c.Model == carModel);


            if (!pilotRepository.Models.Any(p => p.FullName == pilotName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            var pilot = pilotRepository.Models.FirstOrDefault(p => p.FullName == pilotName);

            if (pilot.Car != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            pilot.AddCar(car);

            FormulaOneCarRepository.Remove(car);

            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName,car.GetType().Name, carModel);
          
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (!raceRepository.Models.Any(r => r.RaceName == raceName))
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (!pilotRepository.Models.Any(p => p.FullName == pilotFullName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            var pilot = pilotRepository.Models.FirstOrDefault(p => p.FullName == pilotFullName);
            var race = raceRepository.Models.FirstOrDefault(r => r.RaceName == raceName);

            if (pilot.CanRace == false || race.Pilots.Any(r => r.FullName == pilotFullName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);

            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar formulaOneCar = null;

            if (type == "Ferrari")
            {
                formulaOneCar = new Ferrari(model,horsepower,engineDisplacement);
            }
            else if (type == "Williams")
            {
                formulaOneCar=new Williams(model,horsepower,engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            if (FormulaOneCarRepository.Models.Contains(formulaOneCar))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, formulaOneCar.Model));
            }

            FormulaOneCarRepository.Add(formulaOneCar);

            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.Models.Any(p => p.FullName == fullName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            Pilot pilot = new Pilot(fullName);

            pilotRepository.Add(pilot);

            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
            
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.Models.Any(r => r.RaceName == raceName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            Race race = new Race(raceName, numberOfLaps);

            raceRepository.Add(race);

            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            StringBuilder result = new StringBuilder();

            pilotRepository.Models.OrderByDescending(p => p.NumberOfWins);

            foreach (var pilot in pilotRepository.Models)
            {
                result.AppendLine(pilot.ToString());
            }

            return result.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder result = new StringBuilder();
            raceRepository.Models.Select(r => r.TookPlace == true);

            foreach (var race in raceRepository.Models)
            {
                result.AppendLine(race.RaceInfo());
            }

            return result.ToString().TrimEnd();

        }

        public string StartRace(string raceName)
        {
            if (!raceRepository.Models.Any(r => r.RaceName == raceName))
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            
            var race = raceRepository.Models.FirstOrDefault(r => r.RaceName == raceName);

            if (race.Pilots.Count() < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace == true)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }



            race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps));
            race.Pilots.First().WinRace();

            StringBuilder finalScore = new StringBuilder();
            int pilotsCounter = 1;

            foreach (var pilot in race.Pilots)
            {
                if (pilotsCounter == 1)
                {
                    finalScore.AppendLine(String.Format(OutputMessages.PilotFirstPlace,pilot.FullName,raceName));
                }
                if (pilotsCounter == 2)
                {
                    finalScore.AppendLine(String.Format(OutputMessages.PilotSecondPlace, pilot.FullName, raceName));
                }
                if (pilotsCounter == 3)
                {
                    finalScore.AppendLine(String.Format(OutputMessages.PilotThirdPlace, pilot.FullName, raceName));
                    break;
                }

                pilotsCounter++;
            }

            return finalScore.ToString().TrimEnd();

        }
    }
}
