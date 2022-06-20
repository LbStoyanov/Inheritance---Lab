using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        // Implement unit tests here
        [Test]
        public void Athlete_Creation_Working()
        {
            Athlete athlete = new Athlete("Dinko");

            Assert.AreEqual("Dinko", athlete.FullName);
            Assert.AreEqual(false, athlete.IsInjured);
        }

        [Test]
        public void Gym_Creation_Working()
        {
            //Athlete athlete = new Athlete("Dinko");
            Gym gym = new Gym("Pri Dinko",5);

            Assert.AreEqual("Pri Dinko", gym.Name);
            Assert.AreEqual(5, gym.Capacity);
            Assert.AreEqual(0,gym.Count);
        }

        [Test]
        public void Gym_Creation_With_Invalid_Name_Working()
        {
            //Athlete athlete = new Athlete("Dinko");


            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym("", 5);
            });
        }

        [Test]
        public void Gym_Creation_With_Invalid_Capacity_Working()
        {
            //Athlete athlete = new Athlete("Dinko");


            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("Pri Dinko", -1);
            });
        }

        [Test]
        public void AddAthlete_In_Full_Gym_Working()
        {
            Gym gym = new Gym("Pri Dinko", 1);
            Athlete athlete = new Athlete("Dinko");
            Athlete athlete2 = new Athlete("Dinko2");
            gym.AddAthlete(athlete);


            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete2);
            });
        }

        [Test]
        public void AddAthlete_In_Freespace_Gym_Working()
        {
            Gym gym = new Gym("Pri Dinko", 2);
            Athlete athlete = new Athlete("Dinko");
            Athlete athlete2 = new Athlete("Dinko2");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.AreEqual(2, gym.Count);

        }

        [Test]
        public void RemoveAthlete_with_Inexisting_Athlete_Working()
        {
            Gym gym = new Gym("Pri Dinko", 2);
            Athlete athlete = new Athlete("Dinko");
            Athlete athlete2 = new Athlete("Dinko2");
            Athlete athlete3 = new Athlete("Dinko3");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Dinko3");
            });

        }

        [Test]
        public void RemoveAthlete_with_Existing_Athlete_Working()
        {
            Gym gym = new Gym("Pri Dinko", 2);
            Athlete athlete = new Athlete("Dinko");
            Athlete athlete2 = new Athlete("Dinko2");
            
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);
            gym.RemoveAthlete(athlete2.FullName);

            Assert.AreEqual(1, gym.Count);

        }

        [Test]
        public void InjureAthlete_with_Existing_Athlete_Working()
        {
            Athlete athlete = new Athlete("Dinko");
            Gym gym = new Gym("Pri Dinko", 5);
            gym.AddAthlete(athlete);
            gym.InjureAthlete(athlete.FullName);
           
          
            Assert.AreEqual(true, athlete.IsInjured);
        }

        [Test]
        public void InjureAthlete_with_Inexisting_Athlete_Working()
        {
            Athlete athlete = new Athlete("Dinko");
            Athlete athlete2 = new Athlete("Dinko2");
            Gym gym = new Gym("Pri Dinko", 5);
            gym.AddAthlete(athlete);
            

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete(athlete2.FullName);
            });

        }

        [Test]
        public void Report_Method_Working()
        {
            Gym gym = new Gym("Pri Dinko", 5);

            Athlete athlete = new Athlete("Dinko");
            Athlete athlete2 = new Athlete("Dinko2");
            
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            gym.InjureAthlete(athlete2.FullName);

            var report = gym.Report();

            Assert.AreEqual("Active athletes at Pri Dinko: Dinko", report);

        }

        [Test]
        public void Report_Method_With_Empty_Gym_Working()
        {
            Gym gym = new Gym("Pri Dinko", 5);

            Athlete athlete = new Athlete("Dinko");
            Athlete athlete2 = new Athlete("Dinko2");


            var report = gym.Report();

            Assert.AreEqual("Active athletes at Pri Dinko: ", report);

        }
    }
}
