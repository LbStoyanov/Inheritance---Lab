using System;

namespace PolymorphismEx
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string carInput = Console.ReadLine();

            string[] carInfo = carInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);


            Car car = new Car(carTankCapacity, carFuelQuantity, carFuelConsumption);


            string truckInput = Console.ReadLine();

            string[] truckInfo = truckInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            Truck truck = new Truck(truckTankCapacity, truckFuelQuantity, truckFuelConsumption);

            string busInput = Console.ReadLine();
            string[] busInfo = busInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            Bus bus = new Bus(busTankCapacity, busFuelQuantity, busFuelConsumption);


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] command = Console.ReadLine().Split();

                    string action = command[0];
                    string vehicle = command[1];
                    double value = double.Parse(command[2]);

                    IVehicle currentVehicle = GetVehicleType(car, truck, bus, vehicle);

                    if (action == "Drive")
                    {
                        if (currentVehicle.CanDrive(value))
                        {
                            currentVehicle.Drive(value);
                            Console.WriteLine($"{vehicle} travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine($"{vehicle} needs refueling");
                        }
                    }
                    else if (action == "DriveEmpty")
                    {
                        bus.IsEmpty = true;

                        if (currentVehicle.CanDrive(value))
                        {
                            bus.Drive(value);
                            bus.IsEmpty = false;
                            Console.WriteLine($"{vehicle} travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine($"{vehicle} needs refueling");
                        }
                    }
                    else
                    {
                        if (currentVehicle.CanRefuel(value))
                        {
                            currentVehicle.Refuel(value);
                        }
                        else
                        {
                            Console.WriteLine($"Cannot fit {value} fuel in the tank");
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message); 
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }

        private static IVehicle GetVehicleType(Car car, Truck truck, Bus bus, string vehicle)
        {
            
            if (vehicle == "Car")
            {
                return car;
            }
            else if (vehicle == "Truck")
            {
                return truck;
            }
            return bus;
        }
    }
}
