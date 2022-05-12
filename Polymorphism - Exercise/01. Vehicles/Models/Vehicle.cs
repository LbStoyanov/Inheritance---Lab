using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        protected Vehicle(double tankCapacity,double fuelQuantity, double fuelConsumption)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumption;

        }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            private set
            {
                if (value > this.TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public virtual double FuelConsumptionPerKm { get;protected set; }
        
        public double TankCapacity { get;}
        public bool IsEmpty { get;  set; }

        public bool CanDrive(double kilometers)
            => this.FuelQuantity - (kilometers * this.FuelConsumptionPerKm) >= 0;

        public bool CanRefuel(double littersOfFuel)
             => this.FuelQuantity + littersOfFuel <= this.TankCapacity;



        public  void Drive(double distance)
        {
            if (CanDrive(distance))
            {
                this.FuelQuantity -= distance * this.FuelConsumptionPerKm;
            }
        }
        public virtual void Refuel(double littersOfFuel)
        {

            if (littersOfFuel <=0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (CanRefuel(littersOfFuel))
            {
                this.FuelQuantity += littersOfFuel;
            }
        }
    }
}
