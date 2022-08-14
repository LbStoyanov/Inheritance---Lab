using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> units;
        public UnitRepository()
        {
            this.units = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => this.units.AsReadOnly();
        public void AddItem(IMilitaryUnit model)
        {
            this.units.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return this.units.FirstOrDefault(x => x.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            IMilitaryUnit military = this.FindByName(name);

            return this.units.Remove(military);
        }
    }
}
