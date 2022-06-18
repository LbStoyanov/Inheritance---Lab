using Gym.Models.Equipment.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {
        protected Equipment(int v1, int v2)
        {
        }

        private Equipment(double weight, decimal price)
        {
            Weight = weight;
            Price = price;
        }

        public double Weight { get; }

        public decimal Price { get; }
    }
}
