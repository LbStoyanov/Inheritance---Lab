using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Paladin : Hero
    {
        private int power;
        public Paladin(string name)
            : base(name,100)
        {
        }

       

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
