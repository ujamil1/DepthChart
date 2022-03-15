using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepthChart.Tests
{
    [TestClass]
    public class DepthChartServiceTest
    {
        Service.IDepthChartService _depthChart;

        public DepthChartServiceTest() {
            _depthChart = new Service.NFLDepthChartService();
        }

        [TestMethod]
        public void DUPLICATEPOSITION_THROWS_EXCEPTION() {

            var positions = new string[] { "LWR", "RWR", "LWR" };

            Assert.ThrowsException<ArgumentException>(() => _depthChart.Initialize("Offence", positions));
        }

        [TestMethod]
        public void ADD_TO_INVALIDPOSITION_THROWS_EXCEPTION() {

            var positions = new string[] { "LWR", "RWR", "LT", "LG" };

            _depthChart.Initialize("Offence", positions);

            Assert.ThrowsException<KeyNotFoundException>(() => _depthChart.AddPlayerToDepthChart("XYZ", new Model.Player(1, "Test")));
        }
    }
}
