using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.TypeAccount
{
    class BonusPointsGameAccount : GameAccount
    {
        private int consecutiveWins = 0;

        public override int CalculatePoints(int gameRating)
        {

            if (consecutiveWins >= 1)
            {
                return gameRating + 20;
            }

            consecutiveWins++;
            return gameRating;
        }
        public override void LoseGame(Game game, int gameRating)
        {
            base.LoseGame(game, gameRating);
            consecutiveWins = 0;
        }
    }
}
