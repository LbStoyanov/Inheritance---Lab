using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<Hero>
    {

        private List<Hero> models;
        public IReadOnlyCollection<Hero> Models { get { return this.models.AsReadOnly(); } }

        public void Add(Hero model)
        {
            this.models.Add(model);
        }

        public Hero FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(Hero model)
        {
            return this.models.Remove(model);
        }
    }
}
