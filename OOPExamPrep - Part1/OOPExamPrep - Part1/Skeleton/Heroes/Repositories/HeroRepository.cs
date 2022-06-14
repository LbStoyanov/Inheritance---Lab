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
        private List<IHero> heroes;
        public HeroRepository()
        {
            heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models { get { return this.heroes.AsReadOnly(); } }

        //IReadOnlyCollection<IHero> IRepository<IHero>.Models { get { return this.models.AsReadOnly(); } }


        public void Add(IHero model)
        {
            heroes.Add(model);
        }


        public bool Remove(IHero model)
        {
          
            var result = heroes.Remove(model);

            return result;

        }

        IHero IRepository<IHero>.FindByName(string name)
        {
            return heroes.FirstOrDefault(x => x.Name == name);
        }
    }
}
