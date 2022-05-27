namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [TestCaseSource("TestCaseConstructorData")]
        public void Test_If_Constructor_Create_Valid_Positiv_Data(Person[] people,int expectedCount)
        {
            Database database = new Database(people);

            Assert.AreEqual(expectedCount, database.Count);

        }

        [TestCaseSource("TestCaseAddData")]
        public void Test_If_AddMethod_Create_Valid_Positiv_Data(
            Person[] ctorPeople, Person[] peopletoAdd, int expectedCount)
        {
            Database database = new Database(ctorPeople);

            foreach (var person in peopletoAdd)
            {
                database.Add(person);
            }

            Assert.AreEqual(expectedCount, database.Count);

        }
        [TestCaseSource("TestCaseAddInvalidData")]
        public void Add_ShouldThrowInvalidOperationExeption_WithInvalid_Data_NegativeTest(
            Person[] ctorPeople, Person[] peopleToAdd, int expectedCount,Person inPerson)
        {
            Database database = new Database(ctorPeople);

            foreach (var person in peopleToAdd)
            {
                database.Add(person);
            }

            Assert.Throws<InvalidOperationException>(
                () => database.Add(inPerson));
        }

        public static IEnumerable<TestCaseData> TestCaseAddInvalidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                  new TestCaseData(
                     new Person[]
                     {
                         new Person(1, "Iubi"),
                         new Person(2, "Kircho"),
                         new Person(3, "Hasan"),
                         new Person(4, "Komara"),
                         new Person(5, "Kompira"),
                         new Person(6, "Kochana"),
                         new Person(7, "Kuchkara"),
                         new Person(8, "Kriviq"),
                         new Person(9, "Praviq"),
                         new Person(10, "Zabludeniq"),
                         new Person(11, "Zaribeniq"),
                         new Person(12, "Zaslepeniq"),
                         new Person(11, "Zanemareniq"),
                     },
                     new Person[]
                     {
                         new Person(14, "Kocho"),
                         new Person(15, "Mocho"),
                         new Person(16, "Garabet"),
                     },
                     new Person(17,"Franco")
                     ),
                  new TestCaseData(
                     new Person[]
                     {
                     },
                     new Person[]
                     {
                         new Person(1, "Koncho"),
                         new Person(2, "Moncho"),
                         new Person(3, "Turbalan"),

                     },
                     new Person(7, "Turbalan"))
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseAddData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                  new TestCaseData(
                     new Person[]
                     {
                         new Person(1, "Iubi"),
                         new Person(2, "Kircho"),
                         new Person(3, "Hasan"),
                     },
                     new Person[]
                     {
                         new Person(4, "Kocho"),
                         new Person(5, "Mocho"),
                         new Person(6, "Garabet"),
                     },
                     6),
                  new TestCaseData(
                     new Person[]
                     {
                     },
                     new Person[]
                     {
                         new Person(1, "Koncho"),
                         new Person(2, "Moncho"),
                         new Person(3, "Turbalan"),

                     },3)
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseConstructorData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                   new TestCaseData(
                     new Person[]
                     {
                     new Person(1, "Iubi"),
                     new Person(2, "Kircho"),
                     new Person(3, "Hasan"),
                     },3),
                   new TestCaseData(
                     new Person[]
                     {

                     }, 0)
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }
    }
}
