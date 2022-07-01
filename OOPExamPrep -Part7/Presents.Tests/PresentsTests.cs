namespace Presents.Tests
{
    using NUnit.Framework;
    using Presents.Test;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void Present_Creation_Woking()
        {
            Present present = new Present("Hurka", 2.5);
            Assert.AreEqual("Hurka", present.Name);
            Assert.AreEqual(2.5, present.Magic);
        }
    }
}
