using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Weapons;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<Weapon> models;
        public IReadOnlyCollection<IWeapon> Models { get { return this.models.AsReadOnly(); } }

     

        public void Add(IWeapon model)
        {
            if (models == null)
            {
                models = new List<Weapon>();
            }

            models.Add((Weapon)model);
        }

        public IWeapon FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }


        public bool Remove(IWeapon model)
        {
            if (models == null)
            {
                return false;
            }

            var result = models.Remove((Weapon)model);
            return result;


        }
    }
}
