
namespace PolymorphismEx
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }
        public override double FuelConsumptionPerKm
            => base.FuelConsumptionPerKm + 0.9;
    }
}
