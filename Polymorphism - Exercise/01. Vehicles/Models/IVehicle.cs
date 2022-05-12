using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismEx
{
    public interface IVehicle
    {
        double FuelQuantity { get;}
        double FuelConsumptionPerKm { get; }
        double TankCapacity { get;}
        bool IsEmpty { get; set; }
        public bool CanDrive(double distance);
        public void  Drive(double distance);
        public void  Refuel(double littersOfFuel);
        public bool  CanRefuel(double littersOfFuel);
    }
}
