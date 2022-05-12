using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public interface IHero
    {
        int Power { get; }

        public string CastAbility();
    }

}
