using System;
using System.Collections.Generic;
using System.Text;

namespace DepthChart.Service
{
    /// <summary>
    /// Factory to create DepthChartService for different sports
    /// </summary>
    public interface IDepthChartServiceFactory
    {
        /// <summary>
        /// Create an instance of DepthChartService with Depth Chart title and positions
        /// </summary>
        /// <param name="title">Title of Depth Chart</param>
        /// <param name="positions">Default Positions in the depth chart</param>
        /// <returns>DepthChartService instance</returns>
        IDepthChartService CreateDepthChartService(string title, string [] positions);
    }

    public class NFLDepthChartServiceFactory : IDepthChartServiceFactory
    {
        public IDepthChartService CreateDepthChartService(string title, string[] positions)
        {
            return new NFLDepthChartService(title, positions);
        }
    }
}
