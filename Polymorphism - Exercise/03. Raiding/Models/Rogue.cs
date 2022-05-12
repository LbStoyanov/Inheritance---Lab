using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Rogue : Hero
    {
        private int power;
        public Rogue(string name)
            : base(name,80)
        {
        }

      

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
