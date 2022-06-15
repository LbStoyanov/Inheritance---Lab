using NUnit.Framework;
using System;

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

        }
    }
}