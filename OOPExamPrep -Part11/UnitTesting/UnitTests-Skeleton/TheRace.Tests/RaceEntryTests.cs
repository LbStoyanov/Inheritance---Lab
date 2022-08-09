using System;
using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UnitCarCreationWorking()
        {
            UnitCar unitCar = new UnitCar("audi", 500, 6.0);

            Assert.AreEqual("audi", unitCar.Model);
            Assert.AreEqual(500, unitCar.HorsePower);
            Assert.AreEqual(6.0, unitCar.CubicCentimeters);
        }

        [Test]
        public void UnitDriverCreationWorking()
        {
            UnitCar audi = new UnitCar("audi", 500, 6.0);
            UnitDriver unitDriver = new UnitDriver("dimitrichko",audi);

            Assert.AreEqual("dimitrichko", unitDriver.Name);
            Assert.AreEqual(audi, unitDriver.Car);
            
        }

        [Test]
        public void UnitDriverCreationWithNullNameThrows()
        {
            UnitCar audi = new UnitCar("audi", 500, 6.0);
            


            Assert.Throws<ArgumentNullException>(() =>
            {
                UnitDriver unitDriver = new UnitDriver(null, audi);
            }, "Name cannot be null!");
        }

        [Test]
        public void RaceEntryCreationWorking()
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.AreEqual(0,raceEntry.Counter);
        }

        [Test]
        public void RaceEntryAddMethodInvalidDriverThrows()
        {
            //UnitCar audi = new UnitCar("audi", 500, 6.0);
            UnitCar audi = new UnitCar("audi", 500, 6.0);
            //UnitDriver unitDriver = new UnitDriver("dimitrichko", audi);
            UnitDriver unitDriver = null;
            RaceEntry raceEntry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddDriver(unitDriver);
            }, "Driver cannot be null.");
        }

        [Test]
        public void RaceEntryAddMethodExistingDriverThrows()
        {
            //UnitCar audi = new UnitCar("audi", 500, 6.0);
            UnitCar audi = new UnitCar("audi", 500, 6.0);
            UnitDriver unitDriver = new UnitDriver("dimitrichko", audi);
            //UnitDriver unitDriver = null;
            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddDriver(unitDriver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddDriver(unitDriver);
            }, $"Driver {unitDriver.Name} is already added.");
        }

        [Test]
        public void RaceEntryAddMethodWorking()
        {
            //UnitCar audi = new UnitCar("audi", 500, 6.0);
            UnitCar audi = new UnitCar("audi", 500, 6.0);
            UnitDriver unitDriver = new UnitDriver("dimitrichko", audi);
            //UnitDriver unitDriver = null;
            RaceEntry raceEntry = new RaceEntry();
            string expected = raceEntry.AddDriver(unitDriver);

            string result = $"Driver {unitDriver.Name} added in race.";

            Assert.AreEqual(expected,result);
        }

        [Test]
        public void CalculateAverageHorsePowerWorking()
        {
            UnitCar audi = new UnitCar("audi", 500, 6.0);
            UnitCar audi2 = new UnitCar("audi", 501, 6.0);
            UnitDriver unitDriver = new UnitDriver("dimitrichko", audi);
            UnitDriver unitDriver2 = new UnitDriver("dimitrichko2", audi2);
            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddDriver(unitDriver);
            raceEntry.AddDriver(unitDriver2);

            double averageHorsePower = (audi.HorsePower + audi2.HorsePower) / 2.0;

           Assert.AreEqual(averageHorsePower,raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerInvalidRacerCountThrows()
        {
            UnitCar audi = new UnitCar("audi", 500, 6.0);
            UnitCar audi2 = new UnitCar("audi", 501, 6.0);
            UnitDriver unitDriver = new UnitDriver("dimitrichko", audi);
            UnitDriver unitDriver2 = new UnitDriver("dimitrichko2", audi2);
            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddDriver(unitDriver);
            //raceEntry.AddDriver(unitDriver2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.CalculateAverageHorsePower();
            });


        }
    }
}