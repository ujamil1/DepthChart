using DepthChart.Model;
using System;
using System.Collections.Generic;

namespace DepthChart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Code challenge to build NFL depth chart for Tampa Bay team.");

            var TomBrady = new Player(12, "Tom Brady");
            var BlaineGabbert = new Player(11, "Blaine Gabbert");
            var KyleTrask = new Player(2, "Kyle Trask");            var MikeEvans = new Player(13, "Mike Evans");
            var JaelonDarden = new Player(1, "Jaelon Darden");
            var ScottMiller = new Player(10, "Scott Miller");            Service.IDepthChartServiceFactory factory = new Service.NFLDepthChartServiceFactory();            Service.IDepthChartService depthChart = factory.CreateDepthChartService("Offence", new string[] { "QB", "LWR" });            depthChart.AddPlayerToDepthChart("QB", TomBrady, 0);
            depthChart.AddPlayerToDepthChart("QB", BlaineGabbert, 1);
            depthChart.AddPlayerToDepthChart("QB", KyleTrask, 2);

            depthChart.AddPlayerToDepthChart("LWR", MikeEvans, 0);
            depthChart.AddPlayerToDepthChart("LWR", JaelonDarden, 1);
            depthChart.AddPlayerToDepthChart("LWR", ScottMiller, 2);            Console.WriteLine("Displaying outcome of execution as per Acceptance criteria.");            var backups = depthChart.GetBackups("QB", TomBrady);
            Print(backups);

            backups = depthChart.GetBackups("QB", JaelonDarden);
            Print(backups);

            backups = depthChart.GetBackups("QB", MikeEvans);
            Print(backups);

            backups = depthChart.GetBackups("QB", BlaineGabbert);
            Print(backups);

            backups = depthChart.GetBackups("QB", KyleTrask);
            Print(backups);

            Console.ReadLine();
        }

        private static void Print(IList<Player> players)
        {
            if (players == null || players.Count == 0)
                Console.WriteLine("<NO LIST>");
            else
            {
                foreach (var item in players)
                    Console.WriteLine(item.ToString());
            }
        }
    }
}
