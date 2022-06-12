using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> models;
        public HeroRepository()
        {
            models = new List<IHero>();
        }
        IReadOnlyCollection<IHero> IRepository<IHero>.Models { get { return this.models.AsReadOnly(); } }


        public void Add(IHero model)
        {
            models.Add(model);
        }


        public bool Remove(IHero model)
        {
          
            var result = models.Remove(model);

            return result;

        }

        IHero IRepository<IHero>.FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}
