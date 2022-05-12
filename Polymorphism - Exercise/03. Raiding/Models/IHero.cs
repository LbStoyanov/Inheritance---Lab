using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public interface IHero
    {
        string Name { get; set; }
        int Power { get; }
        string CastAbility();
        int UnleasheAbilityPower();

    }
}
