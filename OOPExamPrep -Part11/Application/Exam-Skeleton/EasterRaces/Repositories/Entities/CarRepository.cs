using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        public ICar GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(ICar model)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ICar model)
        {
            throw new NotImplementedException();
        }
    }
}
