using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class GameResult
    {
        public string Player { get; }
        public string Opponent { get; }
        public string Winner { get; }
        public int Rating { get; }
        public int GameID { get; }

        public GameResult(string player, string opponent, string winner, int rating, int gameID)
        {
            Player = player;
            Opponent = opponent;
            Winner = winner;
            Rating = rating;
            GameID = gameID;
        }

        public GameResult()
        {

        }
    }
}