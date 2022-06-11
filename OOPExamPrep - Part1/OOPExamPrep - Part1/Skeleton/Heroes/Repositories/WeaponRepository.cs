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
      
        public IReadOnlyCollection<IWeapon> Models { get; }

     

        public void Add(IWeapon model)
        {
            
        }

        public IWeapon FindByName(string name)
        {
            return null;
        }


        public bool Remove(IWeapon model)
        {
            //if (models == null)
            //{
            //    return false;
            //}

            //var result = models.Remove((Weapon)model);
            //return result;

            return false;
        }
    }
}
