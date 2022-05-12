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
            int carTankCapacity = int.Parse(carInfo[3]);


            Car car = new Car(carFuelQuantity, carFuelConsumption,carTankCapacity);
            

            string truckInput = Console.ReadLine();

            string[] truckInfo = truckInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            int truckTankCapacity = int.Parse(truckInfo[3]);

            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption,truckTankCapacity);

            string busInput = Console.ReadLine();
            string[] busInfo = truckInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            int busTankCapacity = int.Parse(busInfo[3]);

            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity );


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                string action = command[0];
                string vehicle = command[1];
                double value = double.Parse(command[2]);


                if (action == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        if (car.CanDrive(value))
                        {
                            car.Drive(value);
                            Console.WriteLine($"Car travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Car needs refueling");
                        }
                    }
                    else if(vehicle == "Truck")
                    {
                        if (truck.CanDrive(value))
                        {
                            truck.Drive(value);
                            Console.WriteLine($"Truck travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Truck needs refueling");
                        }
                    }
                    else if(vehicle == "Bus")
                    {
                        if (bus.CanDrive(value))
                        {
                            bus.Drive(value);
                            Console.WriteLine($"Bus travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Bus needs refueling");
                        }
                    }
                }
                else if(action == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        car.Refuel(value,carTankCapacity);
                    }
                    else if(vehicle == "Truck")
                    {
                        truck.Refuel(value,truckTankCapacity);
                    }
                    else
                    {
                        bus.Refuel(value, busTankCapacity);
                    }
                }
                else
                {
                    if (bus.CanDrive(value))
                    {
                        bus.Drive(value);
                    }
                }
            }
            
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");

        }
    }
}
