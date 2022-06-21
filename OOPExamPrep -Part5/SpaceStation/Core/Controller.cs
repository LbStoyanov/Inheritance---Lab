using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
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
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }

        public string RetireAstronaut(string astronautName)
        {
            throw new NotImplementedException();
        }
    }
}
