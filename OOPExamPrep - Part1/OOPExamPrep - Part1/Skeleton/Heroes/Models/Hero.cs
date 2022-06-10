using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models
{
    public abstract class Hero : IHero
    {
        public string Name => throw new NotImplementedException();

        public int Health => throw new NotImplementedException();

        public int Armour => throw new NotImplementedException();

        public IWeapon Weapon => throw new NotImplementedException();

        public bool IsAlive => throw new NotImplementedException();

        public void AddWeapon(IWeapon weapon)
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(int points)
        {
            throw new NotImplementedException();
        }
    }
}
