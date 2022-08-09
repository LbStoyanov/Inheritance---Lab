using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly ICollection<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }
        public IRace GetByName(string name)
        {
            return this.races.FirstOrDefault(m => m.Name == name);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return (IReadOnlyCollection<IRace>)this.races;
        }

        public void Add(IRace model)
        {
            this.races.Add(model);
        }

        public bool Remove(IRace model)
        {
            return this.races.Remove(model);
        }
    }
}
