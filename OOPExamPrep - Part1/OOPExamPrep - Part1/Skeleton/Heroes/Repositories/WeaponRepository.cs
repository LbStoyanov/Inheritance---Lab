using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        public IReadOnlyCollection<IWeapon> Models => new List<IWeapon>();

        public void Add(IWeapon model)
        {
            
        }

        public IWeapon FindByName(string name)
        {
            return Models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IWeapon model)
        {
            if (Models.Contains(model))
            {
                return true;
            }

            return false;
        }
    }
}
