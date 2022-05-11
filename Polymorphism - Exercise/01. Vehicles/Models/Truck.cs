
namespace PolymorphismEx
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            
        }

        public override double FuelConsumptionPerKm
            => base.FuelConsumptionPerKm + 1.6;

        public override void Refuel(double littersOfFuel)
        {
            littersOfFuel *= 0.95;
            base.Refuel(littersOfFuel);
        }
    }
}
