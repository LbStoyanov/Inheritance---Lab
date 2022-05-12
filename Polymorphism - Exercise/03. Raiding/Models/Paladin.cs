using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Paladin : Hero
    {
        private int power;
        public Paladin(string name)
            : base(name)
        {
        }

        public override int Power
        {
            get { return power; }
            set
            {
                power = 100;
            }
        }

        public override string CastAbility()
        {
            return $"Paladin - {Name} healed for {Power}";
        }
    }
}
