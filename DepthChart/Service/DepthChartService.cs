using DepthChart.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DepthChart.Service
{
    public interface IDepthChartService
    {
        /// <summary>
        /// To create a list of all positions within the depth chart
        /// </summary>
        /// <param name="positions">names of the positions</param>
        void Initialize(string depthChartTitle, string[] positions);
        /// <summary>
        /// Add a player to the depth chart for a particular position
        /// </summary>
        /// <param name="position">Position for which player is added</param>
        /// <param name="player">Object containing player information</param>
        /// <param name="position_depth">depth of the player within that position</param>
        void AddPlayerToDepthChart(string position, Player player, int position_depth);
        /// <summary>
        /// Add a player to the depth chart at end
        /// </summary>
        /// <param name="position">Position for which player is added</param>
        /// <param name="player">Object containing player information</param>
        void AddPlayerToDepthChart(string position, Player player);
        /// <summary>
        /// Remove player from a position
        /// </summary>
        /// <param name="position">Position from which player is being removed</param>
        /// <param name="player">Object containing player information</param>
        /// <returns>Player object if it exists, otherwise null</returns>
        Player RemovePlayerFromDepthChart(string position, Player player);
        /// <summary>
        /// Returns list of all backup players of the given player at particular position
        /// </summary>
        /// <param name="position">Position from which player is being removed</param>
        /// <param name="player">Object containing player information</param>
        /// <returns>List of all players with position depth less than given player if found, else empty list</returns>
        IList<Player> GetBackups(string position, Player player);
        /// <summary>
        /// Prints whole depth chart
        /// </summary>
        string GetFullDepthChart();
    }

    public class NFLDepthChartService : IDepthChartService
    {
        protected Dictionary<string, PositionPlayers> _positionPlayersList;

        protected string _title;

        public NFLDepthChartService()
        {
            _positionPlayersList = new Dictionary<string, PositionPlayers>();
        }

        public NFLDepthChartService(string title, string[] positions)
        {
            _positionPlayersList = new Dictionary<string, PositionPlayers>();

            Initialize(title, positions);
        }

        public void Initialize(string depthChartTitle, string[] positions)
        {
            _title = depthChartTitle;

            if (positions != null)
            {
                _positionPlayersList.Clear();

                foreach (var position in positions)
                    _positionPlayersList.Add(position, new PositionPlayers(position));                
            }
        }

        public void AddPlayerToDepthChart(string position, Player player, int position_depth)
        {
            var playerList = _positionPlayersList[position];

            if (playerList != null)
                playerList.Add(player, position_depth);
        }

        public void AddPlayerToDepthChart(string position, Player player)
        {
            var playerList = _positionPlayersList[position];

            if (playerList != null)
                playerList.Append(player);
        }

        public IList<Player> GetBackups(string position, Player player)
        {
            IList<Player> backups = new List<Player>();

            var playerList = _positionPlayersList[position];

            if (playerList != null)
            {
                var position_depth = playerList.IndexOf(player);

                if (position_depth != -1)
                {
                    for (int depth = position_depth + 1; depth < playerList.MaxDepth; depth++)
                        backups.Add(playerList.GetAt(depth));
                }
            }

            return backups;
        }

        public Player RemovePlayerFromDepthChart(string position, Player player)
        {
            var playerList = _positionPlayersList[position];

            if (playerList != null)
                return playerList.Remove(player);

            return null;
        }

        public string GetFullDepthChart()
        {
            StringBuilder depthChartAsString = new StringBuilder();

            foreach (var positionPlayer in _positionPlayersList)
                depthChartAsString.AppendLine(positionPlayer.Value.ToString());

            return depthChartAsString.ToString().Trim();
        }
    }
}
