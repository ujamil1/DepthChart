using System;
using System.Linq;
using System.Collections.Generic;
using DepthChart.Model;

namespace DepthChart.Model
{
    /// <summary>
    /// This maintains a list of players with their rankings for a Position
    /// </summary>
    public interface IPositionPlayers
    {
        int MaxDepth { get; }
        /// <summary>
        /// Add a player to the end of list
        /// </summary>
        /// <param name="player">Object containing player information</param>
        void Append(Player player);
        /// <summary>
        /// Add a player at a particular depth
        /// </summary>
        /// <param name="player">Object containing player information</param>
        /// <param name="position_depth">zero based position depth</param>
        void Add(Player player, int position_depth);
        /// <summary>
        /// Remove a player from the list
        /// </summary>
        /// <param name="player">Object containing player information</param>
        /// <returns>Player object if it exists, otherwise null</returns>
        Player Remove(Player player);
        /// <summary>
        /// Finds position_depth of a player
        /// </summary>
        /// <param name="player">Object containing player information</param>
        /// <returns></returns>
        int IndexOf(Player player);
        /// <summary>
        /// Returns a player at given depth
        /// </summary>
        /// <param name="position_depth"></param>
        /// <returns></returns>
        Player GetAt(int position_depth);
    }

    public class PositionPlayers : IPositionPlayers
    {
        List<Player> _playerList;
        string _title;

        public int MaxDepth => _playerList.Count;

        public PositionPlayers(string positionTitle)
        {
            _title = positionTitle;
            _playerList = new List<Player>();
        }
        public void Add(Player player, int position_depth)
        {
            if (MaxDepth < position_depth)
                throw new ArgumentException("players should be added in order");
            else if (MaxDepth > position_depth)
                _playerList.Insert(position_depth, player);
            else
                Append(player);
        }
        public void Append(Player player)
        {
            _playerList.Add(player);
        }
        public Player Remove(Player player)
        {
            Player removedPlayer = null;

            var depth = IndexOf(player);

            if (depth != -1)
            {
                removedPlayer = _playerList[depth];

                _playerList.RemoveAt(depth);
            }

            return removedPlayer;
        }
        public int IndexOf(Player player)
        {
            for (int idx = 0; idx < MaxDepth; idx++)
            {
                if (_playerList[idx].Equals(player))
                    return idx;
            }

            return -1;
        }
        public Player GetAt(int position_depth)
        {
            if (position_depth < 0 || position_depth >= MaxDepth)
                throw new IndexOutOfRangeException();

            return _playerList[position_depth];
        }
        public override string ToString()
        {
            return $"{_title} - {String.Join(", ", _playerList.AsEnumerable())}";
        }

    }
}
