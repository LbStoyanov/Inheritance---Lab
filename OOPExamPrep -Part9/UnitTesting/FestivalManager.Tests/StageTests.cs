// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 

using System.Collections.Generic;
using System.Linq;
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
            TimeSpan time = new TimeSpan(0, 2, 2);
            TimeSpan time2 = new TimeSpan(0, 2, 3);
            Song song = new Song("Doko doko", time);
            Song song2 = new Song("Doko doko2", time2);

            List<Song> songs = new List<Song>();
            songs.Add(song);
            songs.Add(song2);

           

            Performer performer = new Performer("Penko", "Penkov", 20);

            performer.SongList.Add(song);
            performer.SongList.Add(song2);

            string fullName = "Penko" + " " + "Penkov";

            Assert.AreEqual(fullName,performer.FullName);
            Assert.AreEqual(20,performer.Age);
            Assert.AreEqual(fullName,performer.ToString());

            Assert.AreEqual(songs,performer.SongList);

        }

        [Test]
        public void Stage_Creation_Working()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("Penko", "Penkov", 20);

            Assert.AreEqual(0,stage.Performers.Count);
           
        }


        [Test]
        public void Stage_Add_Performe_Method_With_Null_Value_Throws()
        {
            Stage stage = new Stage();
            Performer performer = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddPerformer(performer);
            });
            
        }

        [Test]
        public void Stage_Add_Performe_Method_With_Invalid_Age_Throws()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("Penko", "Penkov", 10); ;

            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddPerformer(performer);
            });

        }

        [Test]
        public void Stage_Add_Performe_Method_With_Valid_Age_Throws()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("Penko", "Penkov", 20); 
            stage.AddPerformer(performer);

            Assert.AreEqual(1,stage.Performers.Count);

        }

        [Test]
        public void Stage_Add_Song_Method_With_InValid_Song_Throws()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("Penko", "Penkov", 20);
            Song song = null;
            stage.AddPerformer(performer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSong(song);
            });

        }

        [Test]
        public void Stage_Add_Song_Method_With_InValid_Duration_Throws()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("Penko", "Penkov", 20);
            
            stage.AddPerformer(performer);

            TimeSpan time2 = new TimeSpan(0, 0, 0);
            Song song = new Song("Doko doko", time2);

            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSong(song);
            });

        }

        [Test]
        public void Stage_Add_Song_Method_With_Valid_Data_Working()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("Penko", "Penkov", 20);

            stage.AddPerformer(performer);

            TimeSpan time2 = new TimeSpan(0, 1, 30);
            Song song = new Song("Doko doko", time2);

            stage.AddSong(song);
            stage.AddSongToPerformer(song.Name, performer.FullName);

            Assert.AreEqual(1, performer.SongList.Count);

        }

        [Test]
        public void Stage_Add_Song_To_Performer_Working()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("Penko", "Penkov", 20);

            stage.AddPerformer(performer);

            TimeSpan time2 = new TimeSpan(0, 1, 30);
            Song song = new Song("Doko doko", time2);

            stage.AddSong(song);
            stage.AddSongToPerformer(song.Name, performer.FullName);

            string result = $"{song} will be performed by {performer}";

            Assert.AreEqual(result, stage.AddSongToPerformer(song.Name, performer.FullName));

        }

        [Test]
        public void Stage_Play_Method_Working()
        {

            Stage stage = new Stage();
            Performer performer = new Performer("Penko", "Penkov", 20);

            stage.AddPerformer(performer);

            TimeSpan time2 = new TimeSpan(0, 1, 30);
            Song song = new Song("Doko doko", time2);

            stage.AddSong(song);
            stage.AddSongToPerformer(song.Name, performer.FullName);

            string result = $"{1} performers played {performer.SongList.Count} songs";

            Assert.AreEqual(result,stage.Play());

        }

    }
}