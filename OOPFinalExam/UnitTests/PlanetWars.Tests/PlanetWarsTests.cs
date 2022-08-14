using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void WeaponCreationWorking()
            {
                Weapon weapon = new Weapon("Gun", 2.5, 10);
                Assert.AreEqual("Gun", weapon.Name);
                Assert.AreEqual(2.5, weapon.Price);
                Assert.AreEqual(10, weapon.DestructionLevel);
                
            }

            [Test]
            public void WeaponCreationWithNegativPriceThrows()
            {

                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("Gun", -2.5, 10);
                }, "Price cannot be negative.");
              
            }

            [Test]
            public void WeaponIncreaseDestructionLevel()
            {

                Weapon weapon = new Weapon("Gun", 2.5, 10);
                weapon.IncreaseDestructionLevel();

                Assert.AreEqual(11, weapon.DestructionLevel);
                Assert.AreEqual(true, weapon.IsNuclear);

            }

            [Test]
            public void PlanetCreationWorking()
            {
                Planet planet = new Planet("saturn", 200.00);
                Assert.AreEqual("saturn", planet.Name);
                Assert.AreEqual(200.00, planet.Budget);
                Assert.AreEqual(0, planet.Weapons.Count);
            }

            [Test]
            public void PlanetCreationWithNullNameThrows()
            {
                
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(null, 200.00);
                }, "Invalid planet Name");

            }

            [Test]
            public void PlanetCreationWithNegativeBudgetThrows()
            {

                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("saturn", -200.00);
                }, "Budget cannot drop below Zero!");

            }

            [Test]
            public void MilitaryPowerRatioWorking()
            {
                Planet planet = new Planet("saturn", 200.00);
                Weapon weapon = new Weapon("Gun", 2.5, 10);
                Weapon weapon2 = new Weapon("Gun2", 2.5, 10);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                Assert.AreEqual(20, planet.MilitaryPowerRatio);

            }

            [Test]
            public void ProfitWorking()
            {
                Planet planet = new Planet("saturn", 200.00);
                
                planet.Profit(10);

                Assert.AreEqual(210, planet.Budget);

            }

            [Test]
            public void SpendFundsWorking()
            {
                Planet planet = new Planet("saturn", 200.00);

                planet.SpendFunds(10);

                Assert.AreEqual(190, planet.Budget);

            }

            [Test]
            public void SpendFundsThrows()
            {
                Planet planet = new Planet("saturn", 200.00);

                

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(210);
                }, "Not enough funds to finalize the deal.");

            }

            [Test]
            public void AddWeaponThrows()
            {
                Planet planet = new Planet("saturn", 200.00);
                Weapon weapon = new Weapon("Gun", 2.5, 10);
                planet.AddWeapon(weapon);


                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon);
                }, $"There is already a {weapon.Name} weapon.");

            }

            [Test]
            public void AddWeaponWorking()
            {
                Planet planet = new Planet("saturn", 200.00);
                Weapon weapon = new Weapon("Gun", 2.5, 10);
                planet.AddWeapon(weapon);


                Assert.AreEqual(1, planet.Weapons.Count);

            }

            [Test]
            public void RemoveWeaponWorking()
            {
                Planet planet = new Planet("saturn", 200.00);
                Weapon weapon = new Weapon("Gun", 2.5, 10);
                planet.AddWeapon(weapon);
                planet.RemoveWeapon("Gun");


                Assert.AreEqual(0, planet.Weapons.Count);

            }

            [Test]
            public void UpgrateWeaponWorking()
            {
                Planet planet = new Planet("saturn", 200.00);
                Weapon weapon = new Weapon("Gun", 2.5, 10);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("Gun");


                Assert.AreEqual(11, weapon.DestructionLevel);

            }

            [Test]
            public void UpgrateWeaponThrows()
            {
                Planet planet = new Planet("saturn", 200.00);
                Weapon weapon = new Weapon("Gun", 2.5, 10);
                Weapon weapon2 = new Weapon("Gun2", 2.5, 10);
                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("Gun2");
                }, $"{weapon2.Name} does not exist in the weapon repository of {planet.Name}");

            }

            [Test]
            public void DestructOpponentThrows()
            {
                Planet planet = new Planet("saturn", 200.00);
                Planet planet2 = new Planet("saturn", 400.00);
                


                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(planet2);
                }, $"{planet2.Name} is too strong to declare war to!");

            }

            [Test]
            public void DestructOpponentWorking()
            {
                Planet planet = new Planet("saturn", 200.00);
                Planet planet2 = new Planet("saturn2", 100.00);

                Weapon weapon = new Weapon("Gun", 2.5, 10);
                planet.AddWeapon(weapon);

                string result = $"{planet2.Name} is destructed!";

                Assert.AreEqual(result, planet.DestructOpponent(planet2));

            }
        }
    }
}
