using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ComputerCreationShouldWorkCorrectly()
        {
            Computer computer = new Computer("HP", "Pavilion", 1002.22m);

            Assert.AreEqual("HP",computer.Manufacturer);
            Assert.AreEqual("Pavilion",computer.Model);
            Assert.AreEqual(1002.22m,computer.Price);
        }

        [Test]
        public void ComputerManagerCreationShouldWorkCorrectly()
        {
            ComputerManager computerManager = new ComputerManager();

            Assert.AreEqual(0,computerManager.Count);
        }


        [Test]
        public void ComputerManagerAddNullComputerThrows()
        {
            Computer computer = null;
            ComputerManager computerManager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.AddComputer(computer);
            }, "Can not be null!");
        }

        [Test]
        public void ComputerManagerAddExistingComputerThrows()
        {
            Computer computer = new Computer("HP", "Pavilion", 1002.22m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.AddComputer(computer);
            }, "This computer already exists.");
        }

        [Test]
        public void ComputerManagerAddComputerShouldWorking()
        {
            Computer computer = new Computer("HP", "Pavilion", 1002.22m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);

           Assert.AreEqual(1,computerManager.Count);
        }

        [Test]
        public void ComputerManagerRemoveShouldWork()
        {
            Computer computer = new Computer("HP", "Pavilion", 1002.22m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);
            computerManager.RemoveComputer(computer.Manufacturer,computer.Model);

            Assert.AreEqual(0, computerManager.Count);
        }

        [Test]
        public void ComputerManagerRemoveWithNullManufacturerThrows()
        {
            Computer computer = new Computer("HP", "Pavilion", 1002.22m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);
            //computerManager.RemoveComputer(null, "Pavilion");

            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.RemoveComputer("Chiko", "Pavilion");
            }, "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void ComputerManagerRemoveWithNullModelThrows()
        {
            Computer computer = new Computer("HP", "Pavilion", 1002.22m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);
            //computerManager.RemoveComputer(null, "Pavilion");

            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.RemoveComputer("HP", "Chiko");
            });
        }

        [Test]
        public void ComputerManagerGetComputerWithExistingModelShouldWork()
        {
            Computer computer = new Computer("HP", "Pavilion", 1002.22m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);
            
            Assert.AreEqual(computer,computerManager.GetComputer("HP","Pavilion"));
            
        }

        [Test]
        public void ComputerManagerGetComputerWithInexistingModelThrows()
        {
            Computer computer = new Computer("HP", "Pavilion", 1002.22m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.GetComputer("HP", "Baio");
            });

        }

        [Test]
        public void ComputerManagerGetComputerWithInexistingManufacturerThrows()
        {
            Computer computer = new Computer("HP", "Pavilion", 1002.22m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.GetComputer("Baio", "Pavilion");
            });

        }

        [Test]
        public void GetComputersByManufacturerWorking()
        {
            Computer computer = new Computer("HP", "Pavilion", 1002.22m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);

            var computers = new List<Computer>();
            computers.Add(computer);

            Assert.AreEqual(computers,computerManager.GetComputersByManufacturer("HP"));
        }

        [Test]
        public void GetComputersByNonExistingManufacturerWorking()
        {
            Computer computer = new Computer("HP", "Pavilion", 1002.22m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);

            //var computers = new List<Computer>();
            //computers.Add(computer);

            Assert.AreEqual("", computerManager.GetComputersByManufacturer("H"));

            //Assert.Throws<NullReferenceException>(() =>
            //{
                
            //});
        }
    }
}