using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            //TODO REMOVE THE ITEMS FROM THE PLANET
            var astronautsThatCanExplore = astronauts.Where(x => x.Oxygen > 0).ToList();

            foreach (var astronaut in astronautsThatCanExplore)
            {
                List<string> itemsForRemove = new List<string>();

                foreach (var item in planet.Items)
                {
                    astronaut.Bag.Items.Add(item);
                    itemsForRemove.Add(item);
                    astronaut.Breath();

                    if (astronaut.Oxygen <= 0)
                    {
                        break;
                    }

                    if (planet.Items.Count == 0)
                    {
                        return;
                    }
                }

                foreach (var item in itemsForRemove)
                {
                    planet.Items.Remove(item);
                }
            }

        }
    }
}
