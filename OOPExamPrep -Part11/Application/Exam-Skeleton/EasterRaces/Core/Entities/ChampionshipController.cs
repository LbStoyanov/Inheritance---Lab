using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private RaceRepository races;
        private CarRepository cars;
        private DriverRepository drivers;

        public ChampionshipController()
        {
            this.races = new RaceRepository();
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
        }
        public string CreateDriver(string driverName)
        {
            IDriver driver = drivers.GetByName(driverName);

            if (driver == null)
            {
                driver = new Driver(driverName);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            
            drivers.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;

            if (type == "Muscle" )
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            if (cars.GetByName(model) == car)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, car.Model));
            }

            cars.Add(car);

            return string.Format(OutputMessages.CarCreated,car.GetType().Name, car.Model);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);

            if (races.GetByName(name) == race)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            races.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = races.GetByName(raceName);
            IDriver driver = drivers.GetByName(driverName);


            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, race.Name));
            }

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driver.Name));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);

        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = cars.GetByName(carModel);
            IDriver driver = drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded,driverName,carModel);
        }

        public string StartRace(string raceName)
        {
            IRace race = races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3 ));
            }

            var firstThreeDrivers
                = drivers.GetAll().OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();
            var first = firstThreeDrivers[0];
            var second = firstThreeDrivers[1];
            var thirt = firstThreeDrivers[2];

            races.Remove(race);

            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format(OutputMessages.DriverFirstPosition, first.Name, raceName));
            result.AppendLine(string.Format(OutputMessages.DriverSecondPosition, second.Name, raceName));
            result.AppendLine(string.Format(OutputMessages.DriverThirdPosition, thirt.Name, raceName));



            return result.ToString().TrimEnd();
        }
    }
}
