using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;

    public class AquariumsTests
    {
        [Test]
        public void Fish_Creation_Working()
        {
            Fish fish = new Fish("Boika");

            Assert.AreEqual("Boika",fish.Name);
            Assert.AreEqual(true,fish.Available);
        }

        [Test]
        public void Aquarium_Creation_Working()
        {
            //Fish fish = new Fish("Boika");
            Aquarium aquarium = new Aquarium("Pri Boika", 15);

            Assert.AreEqual("Pri Boika", aquarium.Name);
            Assert.AreEqual(15, aquarium.Capacity);
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void Aquarium_Creation_With_Invalid_Name_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(null, 15);
            });
        }

        [Test]
        public void Aquarium_Creation_With_Invalid_Capacity_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("null", -1);
            });
        }

        [Test]
        public void Add_Method_Throws()
        {
            Aquarium aquarium = new Aquarium("Pri Gencho ribaria", 0);

            Fish fish = new Fish("Bai Penko");


            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish);
            });
        }

        [Test]
        public void Add_Method_Working()
        {
            Aquarium aquarium = new Aquarium("Pri Gencho ribaria", 5);

            Fish fish = new Fish("Bai Penko");


           aquarium.Add(fish);

           Assert.AreEqual(1,aquarium.Count);
        }
        [Test]
        public void Remove_Method_Throws()
        {
            Aquarium aquarium = new Aquarium("Pri Gencho ribaria", 5);

            Fish fish = new Fish("Bai Penko");

            aquarium.Add(fish);

            Fish fish2 = new Fish("Ginka Spina");


            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish(fish2.Name);
            });
        }

        [Test]
        public void Remove_Method_Working()
        {
            Aquarium aquarium = new Aquarium("Pri Gencho ribaria", 5);

            Fish fish = new Fish("Bai Penko");

            aquarium.Add(fish);

            Fish fish2 = new Fish("Ginka Spina");

            aquarium.RemoveFish(fish.Name);
            Assert.AreEqual(5,aquarium.Capacity);
        }

        [Test]
        public void SellFish_Method_Working()
        {
            Aquarium aquarium = new Aquarium("Pri Gencho ribaria", 5);

            Fish fish = new Fish("Bai Penko");
            Fish fish2 = new Fish("Ginka Spina");

            aquarium.Add(fish);
            aquarium.Add(fish2);

            aquarium.SellFish(fish2.Name);
           
            Assert.AreEqual(false, fish2.Available);
        }

        [Test]
        public void SellFish_Method_Throws()
        {
            Aquarium aquarium = new Aquarium("Pri Gencho ribaria", 5);

            Fish fish = new Fish("Bai Penko");
            Fish fish2 = new Fish("Ginka Spina");

            aquarium.Add(fish);
            //aquarium.Add(fish2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish(fish2.Name);
            });
        }


        [Test]
        public void Report_Method_Working()
        {
            Aquarium aquarium = new Aquarium("Pri Gencho ribaria", 5);

            Fish fish = new Fish("Bai Penko");
            Fish fish2 = new Fish("Ginka Spina");

            aquarium.Add(fish);
            aquarium.Add(fish2);

            string fishNames = fish.Name + ", " + fish2.Name;

            string report = $"Fish available at {aquarium.Name}: {fishNames}";

            Assert.AreEqual(report,aquarium.Report());
            
        }
    }
}
