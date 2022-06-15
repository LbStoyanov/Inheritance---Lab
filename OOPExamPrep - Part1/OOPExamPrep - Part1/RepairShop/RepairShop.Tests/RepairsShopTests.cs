using NUnit.Framework;
using System;
using System.Linq;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
            [Test]
            public void Car_Creation_Working()
            {
                Car car = new Car("Brakma",5);

                Assert.AreEqual("Brakma", car.CarModel);
                Assert.AreEqual(5, car.NumberOfIssues);
              
            }

            [Test]
            public void Car_IsFixed_Working()
            {
                Car car = new Car("Brakma", 0);

                Assert.AreEqual(true, car.IsFixed);
            }

            [Test]
            public void Garage_Creation_Working()
            {
                //Car car = new Car("Brakma", 0);
                Garage garage = new Garage("Pri dudata", 5);

                Assert.AreEqual("Pri dudata", garage.Name);
                Assert.AreEqual(5, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void Garage_Creation_With_Invalid_Name_Throw()
            {
                //Car car = new Car("Brakma", 0);
                //Garage garage = new Garage("", 5);

                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(null, 5);
                });

            }

            [Test]
            public void Garage_Creation_With_Invalid_MechanichsCount_Throw()
            {
                //Car car = new Car("Brakma", 0);
                //Garage garage = new Garage("", 5);

                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("Pri dudata", 0);
                });

            }

            [Test]
            public void Cars_In_Grage_Property()
            {
                Car car = new Car("Brakma", 1);
                Garage garage = new Garage("Pri dudata", 5);
                garage.AddCar(car);

                Assert.AreEqual(1, garage.CarsInGarage);

            }

            [Test]
            public void Add_Car_In_Grage_With_Available_Mechanics_Method()
            {
                Car car = new Car("Brakma", 1);
                Garage garage = new Garage("Pri dudata", 5);
                garage.AddCar(car);

                Assert.AreEqual(1, garage.CarsInGarage);

            }

            [Test]
            public void Add_Car_In_Grage_With_Unavailable_Mechanics_Method()
            {
                Car car = new Car("Brakma", 1);
                Car car2 = new Car("Brakma2", 1);
                Garage garage = new Garage("Pri dudata", 1);
                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(car2);
                });

            }

            [Test]
            public void Fix_Car_With_Invalid_Car_Method()
            {
                Car car = new Car("Brakma", 1);
                Car car2 = new Car("Kosnik",1);
                Garage garage = new Garage("Pri dudata", 2);
                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("Kosnik");
                });

            }

            [Test]
            public void Fix_Car_With_Valid_Car_Method()
            {
                Car car = new Car("Brakma", 1);
                Car car2 = new Car("Koshnik", 1);
                Garage garage = new Garage("Pri dudata", 2);
                garage.AddCar(car);
                garage.AddCar(car2);
                garage.FixCar("Koshnik");

                Assert.AreEqual(0, car2.NumberOfIssues);
            }

            [Test]
            public void Remove_Fixed_Car_No_Car_Left_Method()
            {
                Car car = new Car("Brakma", 1);
                Car car2 = new Car("Koshnik", 1);
                Garage garage = new Garage("Pri dudata", 2);
                garage.AddCar(car);
                garage.AddCar(car2);
                garage.FixCar("Koshnik");
                garage.FixCar("Brakma");
                garage.RemoveFixedCar();
                

                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void Remove_Fixed_Car_With_Car_Left_Method()
            {
                Car car = new Car("Brakma", 1);
                Car car2 = new Car("Koshnik", 1);
                Car car3 = new Car("Koshnik2", 1);
                Garage garage = new Garage("Pri dudata", 3);
                garage.AddCar(car);
                garage.AddCar(car2);
                garage.AddCar(car3);
               

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                });
            }

            [Test]
            public void Report_Method()
            {
                Car car = new Car("Brakma", 1);
                Car car2 = new Car("Koshnik", 1);
                Car car3 = new Car("Koshnik2", 1);
                Garage garage = new Garage("Pri dudata", 3);
                garage.AddCar(car);
                garage.AddCar(car2);
                garage.AddCar(car3);


                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                });
            }

        }
    }
}