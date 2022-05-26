using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Àxe_Loose_Durability_After_Attack()
        {
            Axe axe = new Axe(10, 20);
            Dummy dummy = new Dummy(100,100);

            axe.Attack(dummy);
            
            Assert.That(axe.DurabilityPoints, Is.EqualTo(19), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void Test_Attack_With_Zero_Durability_Throws_Error()
        {
            Axe axe = new Axe(10, 1);
            Dummy dummy = new Dummy(100, 100);

            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
            
        }
    }
}