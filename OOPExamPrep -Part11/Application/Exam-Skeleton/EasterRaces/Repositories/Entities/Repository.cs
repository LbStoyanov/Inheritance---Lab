using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        private readonly IReadOnlyCollection<T> models;
        protected Repository()
        {
            this.models = new List<T>();
        }
        public T GetByName(string name)
        {
            return this.models.FirstOrDefault(x => x.GetType().Name == name);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.models;
        }

        public void Add(T model)
        {
            this.models.Append(model);
        }

        public bool Remove(T model)
        {
            throw new NotImplementedException();
        }
    }
}
