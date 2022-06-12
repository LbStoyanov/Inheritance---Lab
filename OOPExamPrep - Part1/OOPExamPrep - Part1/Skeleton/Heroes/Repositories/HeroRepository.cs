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
        private List<Hero> models;
        IReadOnlyCollection<IHero> IRepository<IHero>.Models { get { return this.models.AsReadOnly(); } }


        public void Add(IHero model)
        {
            if (models == null)
            {
                models = new List<Hero>();
            }

            models.Add((Hero)model);
        }


        public bool Remove(IHero model)
        {
            if (models == null)
            {
                return false;
            }

            var result = models.Remove((Hero)model);

            return result;

        }

        IHero IRepository<IHero>.FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}
