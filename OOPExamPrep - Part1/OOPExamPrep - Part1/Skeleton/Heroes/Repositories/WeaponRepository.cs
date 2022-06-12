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
        public WeaponRepository()
        {
            models = new List<Weapon>();
        }

        public IReadOnlyCollection<IWeapon> Models { get { return this.models.AsReadOnly(); } }

        public void Add(IWeapon model)
        {
            models.Add((Weapon)model);
        }

        public IWeapon FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }


        public bool Remove(IWeapon model)
        {
            var result = models.Remove((Weapon)model);
            return result;
        }
    }
}
