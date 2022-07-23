using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
    {
        private List<Character> party;
        private List<Item> pool;
		public WarController()
		{
			this.party = new List<Character>();
			this.pool = new List<Item>();
		}

		public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            if (characterType != "Warrior" && characterType != "Priest")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

            Character character = null;

            if (characterType == "Warrior")
            {
                character = new Warrior(name);
            }
            else
            {
                character = new Priest(name);
            }

			this.party.Add(character);

            return string.Format(SuccessMessages.JoinParty, name);
        }

		public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            if (itemName != "FirePotion" && itemName != "HealthPotion")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

			Item item = null;

            if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            else
            {
                item = new HealthPotion();
            }

            this.pool.Add(item);

            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

		public string PickUpItem(string[] args)
		{
            string characterName = args[0];

            if (this.party.All(x => x.Name != characterName))
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, characterName);
            }

            if (this.pool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item itemToAdd = this.pool.Last();

            Character character = this.party.FirstOrDefault(x => x.Name == characterName);

            character.Bag.AddItem(itemToAdd);

            this.pool.Remove(itemToAdd);

            return string.Format(SuccessMessages.PickUpItem, characterName,itemToAdd.GetType().Name);

        }

		public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            if (this.party.All(x => x.Name != characterName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Character character = this.party.FirstOrDefault(x => x.Name == characterName);

            Item item = this.pool.FirstOrDefault(x => x.GetType().Name == itemName);

            character.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, characterName, item.GetType().Name);
        }

		public string GetStats()
		{
			StringBuilder result = new StringBuilder();

            var orderedCharacters = this.party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health);

            foreach (var character in orderedCharacters)
            {
                if (character.IsAlive)
                {
                    result.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: Alive");
                }
                else
                {
                    result.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: Dead");
                }
            }

            return result.ToString().TrimEnd();
        }

		public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            StringBuilder result = new StringBuilder();

            if (this.party.All(x => x.Name != attackerName))
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, attackerName);
            }

            if (this.party.All(x => x.Name != receiverName))
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, receiverName);
            }

            var attacker = this.party.FirstOrDefault(x => x.Name == attackerName);
            var receiver = this.party.FirstOrDefault(x => x.Name == receiverName);

            if (!receiver.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            receiver.TakeDamage(attacker.AbilityPoints);

            result.AppendLine(string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName,
                attacker.AbilityPoints, receiverName, receiver.Health, receiver.BaseHealth, receiver.Armor,
                receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
                result.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));

            }

            return result.ToString().TrimEnd();
        }

		public string Heal(string[] args)
		{
            string healerName = args[0];
            string healingReceiverName = args[1];


            StringBuilder result = new StringBuilder();

            if (this.party.All(x => x.Name != healerName))
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healerName);
            }

            if (this.party.All(x => x.Name != healingReceiverName))
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healingReceiverName);
            }

            Priest healer = (Priest)this.party.FirstOrDefault(x => x.Name == healerName);
            var healingReceiver = this.party.FirstOrDefault(x => x.Name == healingReceiverName);

            if (!healer.IsAlive)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            healer.Heal(healingReceiver);

            return string.Format(SuccessMessages.HealCharacter, healerName, healingReceiverName, healer.AbilityPoints,
                healingReceiverName, healingReceiver.Health);

        }
	}
}
