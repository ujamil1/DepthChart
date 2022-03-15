using DepthChart.Model;
using DepthChart.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DepthChart.Tests
{
    [TestClass]
    public class AcceptanceCriteriaTest
    {
        Service.IDepthChartServiceFactory _factory;        Service.IDepthChartService _depthChartService;
        Player TomBrady, BlaineGabbert, KyleTrask;
        Player MikeEvans, JaelonDarden, ScottMiller;

        public AcceptanceCriteriaTest() {

            _factory = new Service.NFLDepthChartServiceFactory();
            _depthChartService = _factory.CreateDepthChartService("Offence", new string[] { "QB", "LWR" });
            TomBrady = new Player(12, "Tom Brady");
            BlaineGabbert = new Player(11, "Blaine Gabbert");
            KyleTrask = new Player(2, "Kyle Trask");            MikeEvans = new Player(13, "Mike Evans");
            JaelonDarden = new Player(1, "Jaelon Darden");
            ScottMiller = new Player(10, "Scott Miller");


            _depthChartService.AddPlayerToDepthChart("QB", TomBrady, 0);
            _depthChartService.AddPlayerToDepthChart("QB", BlaineGabbert, 1);
            _depthChartService.AddPlayerToDepthChart("QB", KyleTrask, 2);

            _depthChartService.AddPlayerToDepthChart("LWR", MikeEvans, 0);
            _depthChartService.AddPlayerToDepthChart("LWR", JaelonDarden, 1);
            _depthChartService.AddPlayerToDepthChart("LWR", ScottMiller, 2);
        }
        /// <summary>
        /// Acceptance criteria 1: 
        /// getBackups(“QB”, TomBrady)
        /// /* Output */
        /// #11 – Blaine Gabbert
        /// #2 – Kyle Trask
        /// </summary>
        [TestMethod]
        public void TOMBRADY_BACKUPS_ARE_BLAINE_AND_KYLE()
        {
            var backups = _depthChartService.GetBackups("QB", TomBrady);

            Assert.IsNotNull(backups);
            Assert.IsTrue(backups.Count == 2);
            Assert.IsTrue(backups[0].Equals(BlaineGabbert));
            Assert.IsTrue(backups[1].Equals(KyleTrask));
        }

        /// <summary>
        /// Acceptance criteria 2: 
        /// getBackups(“QB”, JaelonDarden))
        /// /* Output */
        /// #10 – Scott Miller
        /// </summary>
        [TestMethod]
        public void JAELON_BACKUP_IS_SCOTT()
        {
            var backups = _depthChartService.GetBackups("LWR", JaelonDarden);

            Assert.IsNotNull(backups);
            Assert.IsTrue(backups.Count == 1);
            Assert.IsTrue(backups[0].Equals(ScottMiller));
        }

        /// <summary>
        /// Acceptance criteria 3: 
        /// getBackups(“QB”, MikeEvans))
        /// /* Output */
        /// <NO LIST>
        /// </summary>
        [TestMethod]
        public void MIKE_HAS_NO_BACKUP()
        {
            var backups = _depthChartService.GetBackups("QB", MikeEvans);

            Assert.IsTrue(backups == null || backups.Count == 0);
        }

        /// <summary>
        /// Acceptance criteria 4: 
        /// getBackups(“QB”, TomBrady)
        /// /* Output */
        /// #11 – Blaine Gabbert
        /// #2 – Kyle Trask
        /// </summary>
        [TestMethod]
        public void BLAINE_BACKUPS_IS_KYLE()
        {
            var backups = _depthChartService.GetBackups("QB", BlaineGabbert);

            Assert.IsNotNull(backups);
            Assert.IsTrue(backups.Count == 1);
            Assert.IsTrue(backups[0].Equals(KyleTrask));
        }

        /// <summary>
        /// Acceptance criteria 4: 
        /// getBackups(“QB”, KyleTrask))
        /// /* Output */
        /// <NO LIST>
        /// </summary>
        [TestMethod]
        public void KYLE_HAS_NO_BACKUP()
        {
            var backups = _depthChartService.GetBackups("QB", KyleTrask);

            Assert.IsTrue(backups == null || backups.Count == 0);
        }

        /// <summary>
        /// Acceptance criteria 5: 
        /// getFullDepthChart()
        /// /* Output */
        /// QB – (#12, Tom Brady), (#11, Blaine Gabbert), (#2, Kyle Trask)
        /// LWR – (#13, Mike Evans), (#1, Jaelon Darden), (#10, Scott Miller)
        /// </summary>
        [TestMethod]
        public void GETFULLDEPTHCHART_RETURNS_EXPECTED_STRING()
        {
            var expected = $"QB - (#12, Tom Brady), (#11, Blaine Gabbert), (#2, Kyle Trask)"
                + System.Environment.NewLine +
                "LWR - (#13, Mike Evans), (#1, Jaelon Darden), (#10, Scott Miller)";

            var actual = _depthChartService.GetFullDepthChart();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Acceptance criteria 5: 
        /// removePlayerFromDepthChart(“WR”, MikeEvans)
        /// getFullDepthChart()
        /// /* Output */
        /// QB – (#12, Tom Brady), (#11, Blaine Gabbert), (#2, Kyle Trask)
        /// LWR – (#1, Jaelon Darden), (#10, Scott Miller)
        /// </summary>
        [TestMethod]
        public void GETFULLDEPTHCHART_AFTER_REMOVING_MIKE_RETURNS_EXPECTED_STRING()
        {
            var expected = $"QB - (#12, Tom Brady), (#11, Blaine Gabbert), (#2, Kyle Trask)"
                + System.Environment.NewLine +
                "LWR - (#1, Jaelon Darden), (#10, Scott Miller)";

            var removedPlayer = _depthChartService.RemovePlayerFromDepthChart("LWR", MikeEvans);

            var actual = _depthChartService.GetFullDepthChart();

            Assert.AreEqual(MikeEvans, removedPlayer);
            Assert.AreEqual(expected, actual);
        }
    }
}
