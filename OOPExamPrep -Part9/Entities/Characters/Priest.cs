using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character,IHealer
    {
        public Priest(string name) 
            : base(name, 50, 25, 40, new Backpack())
        {
            this.BaseHealth = 50;
            this.BaseArmor = 25;
        }

        public void Heal(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                character.Health += this.AbilityPoints;
            }
        }

        public override void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter();
            }
        }
    }
}
