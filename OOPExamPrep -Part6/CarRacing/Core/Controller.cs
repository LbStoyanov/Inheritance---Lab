using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        CarRepository cars;
        RacerRepository racers;
        IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            Car car = null;

            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            this.cars.Add(car);

            return String.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            Racer racer = null;

            if (!cars.Models.Any(x => x.VIN == carVIN))
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            ICar car = cars.Models.FirstOrDefault(x => x.VIN == carVIN);

            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username,car);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            racers.Add(racer);

            return string.Format(OutputMessages.SuccessfullyAddedRacer, racer.Username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            if (racers.Models.Any(x => x.Username == racerOneUsername))
            {
                throw new ArgumentException(ExceptionMessages.RacerCannotBeFound, racerOneUsername);
            }

            if (racers.Models.Any(x => x.Username == racerTwoUsername))
            {
                throw new ArgumentException(ExceptionMessages.RacerCannotBeFound, racerTwoUsername);
            }

            IRacer racerOne = racers.Models.FirstOrDefault(x => x.Username == racerOneUsername);
            IRacer racerTwo = racers.Models.FirstOrDefault(x => x.Username == racerTwoUsername);

            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
