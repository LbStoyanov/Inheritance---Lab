using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public abstract class Vehicle
    {
        
        protected Vehicle(double fuelQuantity,double fuelConsumption,double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }
        public  double FuelQuantity { get; set; }
        public virtual double TankCapacity { get; set; }

        public bool CanDrive(double kilometers)
            => this.FuelQuantity - (kilometers * this.FuelConsumptionPerKm) >= 0;        

        public virtual double FuelConsumptionPerKm { get; set; }
        public  void Drive(double distance)
        {
            if (CanDrive(distance))
            {
                this.FuelQuantity -= distance * this.FuelConsumptionPerKm;
            }
        }
        public virtual void Refuel(double littersOfFuel)
        {
            this.FuelQuantity += littersOfFuel;
        }


    }
}
