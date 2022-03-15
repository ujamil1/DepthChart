using DepthChart.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepthChart.Tests
{
    [TestClass]
    public class PlayerTest
    {
        public PlayerTest() {

        }

        [TestMethod]
        public void PLAYER_WITH_SAME_NAME_AND_NUMBER_ARE_SAME()
        {
            var player1 = new Player(1, "John Michael");
            var player2 = new Player(1, "John Michael");

            Assert.AreEqual(player1, player2);
        }

        [TestMethod]
        public void NAME_IS_CASE_INSENSITIVE()
        {
            var player1 = new Player(1, "JOHN MICHAEL");
            var player2 = new Player(1, "john michael");

            Assert.AreEqual(player1, player2);
        }
    }
}
