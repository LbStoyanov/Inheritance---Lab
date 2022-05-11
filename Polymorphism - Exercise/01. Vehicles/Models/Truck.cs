using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private int travelledDistance;
        public Truck(double fuelQuantity, double fuelConsumption) 
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.travelledDistance = 0;

        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            private set
            {
                this.fuelQuantity = value;
            }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            private set
            {
                fuelConsumption = value + 0.9;
            }
        }

        public int TravelledDistance { get;private set; }

        public override void Drive(int distance)
        {
            double requiredFuel = distance * (this.fuelConsumption * 100);

            if (this.fuelQuantity <= requiredFuel)
            {
                this.fuelQuantity -= requiredFuel;
                this.travelledDistance += distance;
            }
        }

        public override void Refuel(double litters)
        {
            double fuelThatCanBeRefueled = litters * 0.95;
            this.fuelQuantity += fuelThatCanBeRefueled;
        }
    }
}
