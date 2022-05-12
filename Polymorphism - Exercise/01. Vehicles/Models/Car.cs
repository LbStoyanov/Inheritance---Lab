
namespace PolymorphismEx
{
    public class Car : Vehicle
    {
        public Car(double tankCapacity,double fuelQuantity, double fuelConsumption)
            : base(tankCapacity,fuelQuantity, fuelConsumption)
        {
        }
        public override double FuelConsumptionPerKm
            => base.FuelConsumptionPerKm + 0.9;


    }
}
