using System;
using KBS1;
using NUnit.Framework;
using UnitTests.Util;

namespace UnitTests
{
    [TestFixture]
    public class ControllerTest
    {

        [TestCase(true)]
        [TestCase(false)]
        public void Controller_FindPlayer(bool hasPlayer)
        {
            var player = new TestPlayer(new Vector(20, 20));
            LevelUtil.CreateLevel(hasPlayer ? new GameObject[] {player} : new GameObject[] { });

            void Action() => Controller.FindPlayer();

            if (!hasPlayer)
            {
                Assert.Catch<NullReferenceException>(Action);
            }
            else
            {
                Assert.DoesNotThrow(Action);
            }
        }
    }
}