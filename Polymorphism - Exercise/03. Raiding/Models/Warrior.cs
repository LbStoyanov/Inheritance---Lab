using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Warrior : Hero
    {
        private int power;
        public Warrior(string name)
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
            return $"Warrior - {Name} hit for {Power} damage";
        }
    }
}
