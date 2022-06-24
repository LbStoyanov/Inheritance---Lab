using NUnit.Framework;
using Robots;
using System;
namespace Robots
{
    public class RobotsTests
    {
        [Test]
        public void Robot_Creation_Working()
        {
            Robot robot = new Robot("Chicho Mitko", 10);

            Assert.AreEqual("Chicho Mitko", robot.Name);
            Assert.AreEqual(10, robot.Battery);
            Assert.AreEqual(10, robot.MaximumBattery);
        }

        [Test]
        public void RobotManager_Creation_Woking()
        {
            RobotManager robotManager = new RobotManager(10);

            Assert.AreEqual(10, robotManager.Capacity);
            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void RobotManager_Creation_With_Invalid_Capacity_Throw()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManager = new RobotManager(-10);
            });
        }

        [Test]
        public void RobotManager_Add_Method_With_Inexisting_Robot_Working()
        {

            RobotManager robotManager = new RobotManager(10);
            Robot robot = new Robot("Chicho Mitko", 10);
            Robot robot2 = new Robot("Chicho Penko", 10);
            robotManager.Add(robot);
            robotManager.Add(robot2);
            Assert.AreEqual(2, robotManager.Count);
        }

        [Test]
        public void RobotManager_Add_Method_With_Existing_Robot_Throw()
        {

            RobotManager robotManager = new RobotManager(10);
            Robot robot = new Robot("Chicho Mitko", 10);
            Robot robot2 = new Robot("Chicho Penko", 10);
            robotManager.Add(robot);
            robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot);
            });
        }

        [Test]
        public void RobotManager_Add_Method_With_Equal_CapacityAndCount_Throw()
        {

            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Chicho Mitko", 10);
            Robot robot2 = new Robot("Chicho Penko", 10);
            robotManager.Add(robot);
            //robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot2);
            });
        }

        [Test]
        public void RobotManager_Remove_Method_With_Exisitng_Robot_Working()
        {

            RobotManager robotManager = new RobotManager(10);
            Robot robot = new Robot("Chicho Mitko", 10);
            // Robot robot2 = new Robot("Chicho Penko", 10);
            robotManager.Add(robot);
            robotManager.Remove(robot.Name);
            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void RobotManager_Remove_Method_With_Inexisting_Robot_Throw()
        {

            RobotManager robotManager = new RobotManager(10);
            Robot robot = new Robot(null, 10);
            // Robot robot2 = new Robot("Chicho Penko", 10);
            //robotManager.Add(robot);
            //robotManager.Remove(robot.Name);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove(robot.Name);
            });
        }

        [Test]
        public void RobotManager_Work_Method_With_Exisitng_Robot_Working()
        {

            RobotManager robotManager = new RobotManager(10);
            Robot robot = new Robot("Chicho Mitko", 11);
            // Robot robot2 = new Robot("Chicho Penko", 10);
            robotManager.Add(robot);
            robotManager.Work(robot.Name, "cleaner", 10);
            Assert.AreEqual(1, robot.Battery);
        }

        [Test]
        public void RobotManager_Work_Method_With_Inexisitng_Robot_Throw()
        {

            RobotManager robotManager = new RobotManager(10);
            Robot robot = new Robot(null, 11);
            Robot robot2 = new Robot("Chicho Penko", 10);
            robotManager.Add(robot);
            robotManager.Add(robot2);
            string name = "Giki";


            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work(name, "cleaner", 10);
            });
        }

        [Test]
        public void RobotManager_Work_Method_With_Smaller_Battery_Throw()
        {

            RobotManager robotManager = new RobotManager(10);
            Robot robot2 = new Robot("Chicho Penko", 9);
            robotManager.Add(robot2);


            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work(robot2.Name, "cleaner", 10);
            });
        }

        [Test]
        public void RobotManager_Charge_Method_With_Null_Robot_Throw()
        {

            RobotManager robotManager = new RobotManager(10);
            Robot robot2 = new Robot("Chicho Penko", 9);
            robotManager.Add(robot2);


            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("Ganko");
            });
        }

        [Test]
        public void RobotManager_Charge_Method_With_Esisting_Robot_Throw()
        {

            RobotManager robotManager = new RobotManager(10);
            Robot robot2 = new Robot("Chicho Penko", 9);
            robotManager.Add(robot2);
            robotManager.Work(robot2.Name, "cleaning", 8);
            robotManager.Charge(robot2.Name);

            Assert.AreEqual(9, robot2.Battery);

        }
    }

}
