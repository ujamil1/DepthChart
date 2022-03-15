using DepthChart.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepthChart.Tests
{
    [TestClass]
    public class PositionPlayerTest
    {
        Player TomBrady, BlaineGabbert, KyleTrask;

        public PositionPlayerTest() {
            TomBrady = new Player(12, "Tom Brady");
            BlaineGabbert = new Player(11, "Blaine Gabbert");
            KyleTrask = new Player(2, "Kyle Trask");
        }

        [TestMethod]
        public void ADD_WITHOUT_ORDER_THROWS_EXCEPTION()
        {
            var positionPlayer = new PositionPlayers("LWR");

            Assert.ThrowsException<ArgumentException>(()=>positionPlayer.Add(TomBrady, 2));
        }

        [TestMethod]
        public void APPEND_ADDS_TO_END()
        {
            var positionPlayer = new PositionPlayers("LWR");

            positionPlayer.Add(TomBrady, 0);
            positionPlayer.Append(BlaineGabbert);

            var depth = positionPlayer.IndexOf(BlaineGabbert);

            Assert.AreEqual(1, depth);
        }
    }
}
