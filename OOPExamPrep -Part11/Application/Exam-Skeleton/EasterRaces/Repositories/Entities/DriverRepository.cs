using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        public IDriver GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(IDriver model)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IDriver model)
        {
            throw new NotImplementedException();
        }

    }
}
