using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Decorations = new List<IDecoration>();
            this.Fish = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }
        public int Capacity { get; private set; }

        public int Comfort
            => this.Decorations.Select(x => x.Comfort).Sum();
        public ICollection<IDecoration> Decorations { get; }
        public ICollection<IFish> Fish { get; }
        public void AddFish(IFish fish)
        {
            if (this.Capacity <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.Capacity--;
            this.Fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        {
            if (this.Fish.Remove(fish))
            {
                this.Capacity++;
                return true;
            }

            return false;
            
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var result = new StringBuilder();

            result.AppendLine($"{this.Name} ({this.GetType().Name}):");
            if (this.Fish.Count <= 0)
            {
                result.AppendLine("Fish: none");
            }
            else
            {
                result.AppendLine($"Fish: {string.Join(", ", this.Fish.Select(x => x.Name).ToList())}");
            }

            result.AppendLine($"Decorations: {this.Decorations.Count}");
            result.AppendLine($"Comfort: {this.Comfort}");

            return result.ToString().TrimEnd();

        }
    }
}
