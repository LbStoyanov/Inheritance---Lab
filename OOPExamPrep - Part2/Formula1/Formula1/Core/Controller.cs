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


            if (!pilotRepository.Models.Any(p => p.FullName == pilotName) || pilotRepository.Models.Any(c => c.Car == car))
            {

            }
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public string RaceReport()
        {
            throw new NotImplementedException();
        }

        public string StartRace(string raceName)
        {
            throw new NotImplementedException();
        }
    }
}
