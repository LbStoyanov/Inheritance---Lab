using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public const double DefaultFuelConsuption = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public virtual double FuelConsumption
            => DefaultFuelConsuption;
        

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public virtual void Drive(double kilomeneters)
        {
            //50 - (10 * 4) = 10 litters

            if (this.Fuel - (kilomeneters * this.FuelConsumption) >= 0)
            {
                this.Fuel -= (kilomeneters * this.FuelConsumption);
            }
        }
    }
}
