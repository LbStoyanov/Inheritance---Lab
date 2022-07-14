using System;
using System.Collections.Generic;
using System.Text;
using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        public string Name { get; }
        public string Species { get; }
        public int Size { get; }
        public decimal Price { get; }
        public void Eat()
        {
            throw new NotImplementedException();
        }
    }
}
