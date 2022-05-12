using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Warrior : Hero
    {
        private int power;
        public Warrior(string name)
            : base(name,100)
        {
        }

       

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
