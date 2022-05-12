using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Bus : Vehicle
    {
        public Bus(double tankCapacity, double fuelQuantity, double fuelConsumption)
            : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumptionPerKm
            => this.IsEmpty
            ? base.FuelConsumptionPerKm
            : base.FuelConsumptionPerKm + 1.4;

    }
}
