
namespace PolymorphismEx
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption,int tankCapacity) 
            : base(fuelQuantity, fuelConsumption,tankCapacity)
        {
            
        }

        public override double FuelConsumptionPerKm
            => base.FuelConsumptionPerKm + 1.6;

        public override void Refuel(double littersOfFuel, int tankCapacity)
        {
            littersOfFuel *= 0.95;
            base.Refuel(littersOfFuel,tankCapacity);
        }
    }
}
