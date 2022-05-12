using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Druid : Hero
    {
        private int power;
        public Druid(string name) 
            : base(name,80)
        {
        }
       
        

        public override string CastAbility()
        {
            return  $"{this.GetType().Name} - {Name} healed for {Power}"; 
        }
    }
}
