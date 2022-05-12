
namespace PolymorphismEx
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public override double FuelConsumptionPerKm
            => base.FuelConsumptionPerKm + 0.9;
    }
}
