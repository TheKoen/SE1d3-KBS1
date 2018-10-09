using System;
using KBS1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class Collider_Test
    {
        [Test]
        public void TestMethod1(bool result)
        {
            //arrange
            Collider collider1 = new Collider(24, );
            Collider collider2 = new Collider(24, );
            bool? answer1 = null;
            bool? answer2 = null;

            //act
            answer1 = collider1.Collides();

            //assert
            NUnit.Framework.Assert.AreEqual(answer1, result);

        }
    }
}
