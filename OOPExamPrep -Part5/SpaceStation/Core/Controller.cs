using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private int exploredPlanetsCount;

        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {

            if (type == "Biologist")
            {
                Biologist biologist = new Biologist(astronautName);
                astronauts.Add(biologist);

            }
            else if (type == "Geodesist")
            {
                Geodesist geodesist = new Geodesist(astronautName);
                astronauts.Add(geodesist);
            }
            else if (type == "Meteorologist")
            {
                Meteorologist meteorologist = new Meteorologist(astronautName);
                astronauts.Add(meteorologist);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            return String.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {

            IPlanet planet = new Planet(planetName);
            planets.Add(planet);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            

            return String.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            Planet planet = (Planet)planets.FindByName(planetName);

            Mission mission = new Mission();

            

            var legitAstronauts = astronauts.Models.Where(a => a.Oxygen > 60).ToList();

            if (legitAstronauts.Count() == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            mission.Explore(planet, legitAstronauts);
            this.exploredPlanetsCount++;

            int deadAstronauts = legitAstronauts.Where(x =>x.Oxygen <= 0).Count();

            return String.Format(OutputMessages.PlanetExplored, planet.Name, deadAstronauts);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.exploredPlanetsCount} planets were explored!");
            result.AppendLine("Astronauts info:");

            foreach (var astronaut in astronauts.Models)
            {
                result.AppendLine($"Name: {astronaut.Name}");
                result.AppendLine($"Oxygen: {astronaut.Oxygen}");

                if (astronaut.Bag.Items.Count == 0)
                {
                    result.AppendLine($"Bag items: none");
                }
                else
                {
                    result.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
            }

            return result.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            if (!astronauts.Models.Any(a => a.Name == astronautName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            var astronautForRetire = astronauts.Models.FirstOrDefault(x => x.Name == astronautName);

            astronauts.Remove(astronautForRetire);

            return String.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
