using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class Rating
    {
        private string playerName;
        private int points;

        public string PlayerName
        {
            get
            {
                return playerName;
            }

            set
            {
                playerName = value;
            }
        }

        public int Points
        {
            get
            {
                return points;
            }

            set
            {
                points = value;
            }
        }

        public Rating()
        {
        }

        public Rating(string name, int points)
        {
            this.PlayerName = name;
            this.Points = points;
        }
    }
}
