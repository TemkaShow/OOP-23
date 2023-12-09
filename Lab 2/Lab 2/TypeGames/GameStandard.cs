using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.TypeGames
{
    class StandardGame : Game
    {
        public override int CalculateWinRating(int rating)
        {
            return rating;
        }

        public override int CalculateLoseRating(int rating)
        {
            return rating;
        }
    }
}
