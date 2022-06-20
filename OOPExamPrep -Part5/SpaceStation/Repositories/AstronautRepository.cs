using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Repositories
{
    internal class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> astronauts;

        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models { get { return this.astronauts.AsReadOnly(); } }

        public void Add(IAstronaut model)
        {
            throw new NotImplementedException();
        }

        public IAstronaut FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IAstronaut model)
        {
            throw new NotImplementedException();
        }
    }
}
