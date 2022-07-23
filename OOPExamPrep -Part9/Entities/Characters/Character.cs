using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get { return this.name;}
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw  new ArgumentNullException(ExceptionMessages.CharacterNameInvalid);
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; protected set; }

        public double Health { get;  set; }

        public double BaseArmor{ get; set; }
        public double Armor{ get; set; }
        public double AbilityPoints { get; protected set; }
        public Bag Bag { get; set; }
		public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                if (this.Armor - hitPoints < 0)
                {
                    var takedDamage = hitPoints - this.Armor;
                    this.Armor = 0;
                    this.Health -= takedDamage;
                }
                else
                {
                    this.Armor -= hitPoints;
                }

                if (this.Health == 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
        }
	}
}