using System;
using System.Collections.Generic;
using System.Text;

namespace DepthChart.Model
{
    public class Player
    {
        protected int Number { get; set; }
        protected string Name { get; set; }

        public Player(int number, string name)
        {
            Number = number;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            var newObj = obj as Player;

            return
                newObj != null
                && newObj.Number.Equals(this.Number)
                && newObj.Name.Equals(this.Name, StringComparison.CurrentCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Number, this.Name);
        }

        public override string ToString()
        {
            return $"(#{Number}, {Name})";
        }
    }
}
