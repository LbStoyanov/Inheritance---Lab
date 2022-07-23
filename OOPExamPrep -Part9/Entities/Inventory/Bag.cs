using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private List<Item> items;
        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
            
        }
        public int Capacity { get; set; }

        public int Load
            => this.Items.Select(x => x.Weight).Sum();

        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            if (this.Items.Any(x => x.GetType().Name == name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            Item itemForRemove = this.Items.FirstOrDefault(x => x.GetType().Name == name);
            this.items.Remove(itemForRemove);

            return itemForRemove;
        }
    }
}
