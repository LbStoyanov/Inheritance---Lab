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
        public Aquarium()
        {
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
        public int Capacity { get; }

        public int Comfort
            => this.Decorations.Select(x => x.Comfort).Sum();
        public ICollection<IDecoration> Decorations { get; }
        public ICollection<IFish> Fish { get; }
        public void AddFish(IFish fish)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFish(IFish fish)
        {
            throw new NotImplementedException();
        }

        public void AddDecoration(IDecoration decoration)
        {
            throw new NotImplementedException();
        }

        public void Feed()
        {
            throw new NotImplementedException();
        }

        public string GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
