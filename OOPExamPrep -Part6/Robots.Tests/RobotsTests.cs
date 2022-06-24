using NUnit.Framework;
using Robots;
using System;
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

}

