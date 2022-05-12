using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Rogue : Hero
    {
        private int power;
        public Rogue(string name)
            : base(name)
        {
        }

        public override int Power
        {
            get { return power; }
            set
            {
                power = 80;
            }
        }

        public override string CastAbility()
        {
            return $"Rogue - {Name} hit for {Power} damage";
        }
    }
}
