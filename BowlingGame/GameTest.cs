using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame
{   
    [TestClass]
    public class GameTest
    {
        private Game g;

        [TestInitialize]
        public void Initialize()
        {
            g = new Game();
        }

        [TestCleanup]
        public void Cleanup()
        {
            g = null;
        }

        [TestMethod]
        public void TestGutterGame()
        {
            int rolls = 20;
            int pins = 0;

            RollMany(rolls, pins);

            Assert.AreEqual(0, g.Score());
        }
        
        [TestMethod]
        public void TestAllOnes()
        {
            int rolls = 20;
            int pins = 1;
            RollMany(rolls, pins);

            Assert.AreEqual(20, g.Score());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            RollSpare();
            g.Roll(3);
            RollMany(17, 0);

            Assert.AreEqual(16, g.Score());
        }

        [TestMethod]
        public void TestOneStrike()
        {
            RollStrike();
            g.Roll(3);
            g.Roll(4);
            RollMany(16, 0);
            Assert.AreEqual(24, g.Score());
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            RollMany(12, 10);

            Assert.AreEqual(300, g.Score());
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }

        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }

        private void RollStrike()
        {
            g.Roll(10);
        }
        
    }
}
