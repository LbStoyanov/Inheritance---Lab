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
    }
}