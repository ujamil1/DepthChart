using DepthChart.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepthChart.Tests
{
    [TestClass]
    public class DepthChartServiceFactoryTest
    {
        [TestMethod]
        public void NFLFACTORY_CREATES_NFLSERVICE()
        {
            var depthChartServiceFactory = new NFLDepthChartServiceFactory();

            var depthChartService = depthChartServiceFactory.CreateDepthChartService("Offence", new string[] { "LWR", "QB" });

            Assert.IsInstanceOfType(depthChartService, typeof(NFLDepthChartService));
        }
    }
}
