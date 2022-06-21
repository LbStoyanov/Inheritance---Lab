using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
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
        }
        public string AddAstronaut(string type, string astronautName)
        {

            if (type == typeof(Biologist).ToString())
            {
                Biologist biologist = new Biologist(astronautName);
                astronauts.Add(biologist);

            }
            else if (type == typeof(Geodesist).ToString())
            {
                Geodesist geodesist = new Geodesist(astronautName);
                astronauts.Add(geodesist);
            }
            else if (type == typeof(Meteorologist).ToString())
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
            Planet planet = new Planet(planetName);
            planet.Items.Add(items.ToString());

            return String.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            Planet planet = (Planet)planets.FindByName(planetName);

            Mission mission = new Mission();

            //int deadAstronauts = 0;

            var legitAstronauts = astronauts.Models.Select(a => a.Oxygen > 60).ToList();

            if (legitAstronauts == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            mission.Explore(planet, (ICollection<Models.Astronauts.Contracts.IAstronaut>)astronauts);
            this.exploredPlanetsCount++;

            return String.Format(OutputMessages.PlanetExplored, planet.Name, legitAstronauts.Count);
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
                    result.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag)}");
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
