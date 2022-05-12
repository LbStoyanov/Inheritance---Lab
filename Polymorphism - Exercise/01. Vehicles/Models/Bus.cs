using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double distance,string busCondition)
        {
            if (busCondition == "DriveEmpty")
            {
                this.FuelConsumptionPerKm = base.FuelConsumptionPerKm + 1.4;
            }
        }

    }
}
