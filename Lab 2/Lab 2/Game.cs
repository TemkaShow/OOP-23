using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{

    abstract class Game
    {
        public static int gameCounter { get; private set; } = 0;

        public int GameID { get; } = gameCounter;

        public abstract int CalculateWinRating(int rating);
        public abstract int CalculateLoseRating(int rating);

        public void PlayGame(List<GameAccount> players, int rating)
        {
            Random random = new Random();
            int CoinFlip = random.Next(2);

            GameAccount winner = players[CoinFlip];
            GameAccount loser = players[1 - CoinFlip];

            Console.WriteLine($"\nГравець {winner.UserName} переміг йому випав орел");
            winner.WinGame(this, CalculateWinRating(rating));
            Console.WriteLine($"Гравець {loser.UserName} програв йому випала решка");
            loser.LoseGame(this, CalculateLoseRating(rating)); 

            Console.WriteLine($"\nПоточний рейтинг гравця {winner.UserName}: {winner.CurrentRating}");
            Console.WriteLine($"Поточний рейтинг гравця {loser.UserName}: {loser.CurrentRating}");

            gameCounter++;
        }
    }

    
}
