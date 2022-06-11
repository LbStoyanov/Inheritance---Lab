using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        public IReadOnlyCollection<IHero> Models => new List<IHero>();

        public void Add(IHero model)
        {
            
        }

        public IHero FindByName(string name)
        {
            return Models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IHero model)
        {
            if (Models.Contains(model))
            {
                return true;
            }

            return false;
        }
    }
}
