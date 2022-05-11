using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public abstract class Vehicle
    {
        
        protected Vehicle(double fuelQuantity,double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumption;
        }
        public  double FuelQuantity { get; set; }

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
