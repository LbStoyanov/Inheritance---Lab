namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [TestCase( new Person[] {1,"Iubi" },)]
        public void Test_If_Constructor_Create_Valid_Positiv_Data(Person[] people,int expectedCount)
        {
            Database database = new Database();

            Assert.AreEqual(1, database.Count);

        }
    }
}