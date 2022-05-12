using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public abstract class Hero : IHero
    {
        protected Hero(string name)
        {
            Name = name;
            Power = 0;
        }

        
        public string Name { get; set; }
        public virtual int Power { get;  set; }

        public virtual string CastAbility()
        {
            return $"{this.GetType()} - {Name} healed for {Power}";
        }

        public virtual int UnleasheAbilityPower()
        {
            return this.Power;
        }
    }
}
