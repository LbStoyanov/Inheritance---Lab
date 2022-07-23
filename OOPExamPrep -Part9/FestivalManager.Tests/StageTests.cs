// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 

using FestivalManager.Entities;

namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void Song_Creation_Working()
        {
            TimeSpan time = new TimeSpan(0,2,2);
           
            Song song = new Song("Doko doko", time);

            string result = $"{song.Name} ({time:mm\\:ss})";

            Assert.AreEqual("Doko doko",song.Name);
            Assert.AreEqual(0, time.Hours);
            Assert.AreEqual(2, time.Minutes);
            Assert.AreEqual(2, time.Seconds);

            Assert.AreEqual(result, song.ToString());
            Assert.AreEqual(time,song.Duration);
        }

        [Test]
        public void Performer_Creation_Working()
        {
            Performer performer = new Performer("Penko", "Penkov", 20);

            string fullName = "Penko" + " " + "Penkov";

            Assert.AreEqual(fullName,performer.FullName);
            Assert.AreEqual(20,performer.Age);
        }

	}
}