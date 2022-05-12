using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Druid : Hero
    {
        private int power;
        public Druid(string name) 
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
            return  $"Druid - {Name} healed for {Power}"; 
        }
    }
}
