using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    abstract class GameAccount
    {
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        public List<GameResult> GameResults { get; set; } = new List<GameResult>();

        public abstract int CalculatePoints(int gameRating);

        public virtual void WinGame(Game game, int gameRating)
        {
            GamesCount++;
            CurrentRating += CalculatePoints(gameRating);
            GameResults.Add(new GameResult(UserName, UserName, UserName, CalculatePoints(gameRating), game.GameID));
        }

        public virtual void LoseGame(Game game, int gameRating)
        {
            GamesCount++;
            CurrentRating -= CalculatePoints(gameRating);
            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }
            GameResults.Add(new GameResult(UserName, UserName, UserName, CalculatePoints(gameRating), game.GameID));
        }

        public void GetStats()
        {
            foreach (GameResult result in GameResults)
            {
                Console.WriteLine($"\nГра #{result.GameID}, гравець {result.Winner} переміг, гра була зіграна на {result.Rating} рейтингу");
            }
        }
    }

}

