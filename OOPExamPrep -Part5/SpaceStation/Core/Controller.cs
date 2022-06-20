using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        public string AddAstronaut(string type, string astronautName)
        {
            if (type == typeof(Biologist).ToString())
            {

            }
            else if (type == typeof(Geodesist).ToString())
            {

            }
            else if (type == typeof(Meteorologist).ToString())
            {

            }
            else
            {

            }
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            throw new NotImplementedException();
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
