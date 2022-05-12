using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity,double fuelConsumption,int tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;

            if (fuelQuantity > tankCapacity)
            {
                this.FuelQuantity = 0;
            }
            this.FuelConsumptionPerKm = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }
        public  double FuelQuantity { get; set; }
       
        public virtual double TankCapacity { get; set; }

        public bool CanDrive(double kilometers)
            => this.FuelQuantity - (kilometers * this.FuelConsumptionPerKm) >= 0;        

        public virtual double FuelConsumptionPerKm { get; set; }
        public virtual void Drive(double distance)
        {
            if (CanDrive(distance))
            {
                this.FuelQuantity -= distance * this.FuelConsumptionPerKm;
            }
        }
        public virtual void Refuel(double littersOfFuel,int tankCapacity)
        {
            if (littersOfFuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (tankCapacity - this.FuelQuantity >= littersOfFuel)
            {
                this.FuelQuantity += littersOfFuel;
            }
            else
            {
                Console.WriteLine($"Cannot fit {littersOfFuel} fuel in the tank");
            }
        }
    }
}
