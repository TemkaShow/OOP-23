using Lab_4.Database.Service;
using System;
using System.Collections.Generic;

namespace Lab_4
{
    abstract class Game
    {
        public GameAccount player1 { get; set; }
        public GameAccount player2 { get; set; }
        public int rating { get; set; }
        public string winner { get; set; }
        public GameService _service { get; set; }
        public Game(GameAccount player1, GameAccount player2, GameService service)
        {
            this.player1 = player1;
            this.player2 = player2;
            _service = service;
        }
        public void PlayGame(GameAccount player1, GameAccount player2)
        {
            Console.Write("\nВведіть рейтинг, на який ви граєте: ");
            rating = int.Parse(Console.ReadLine());
            while (rating <= 0)
            {
                Console.Write("\nРейтинг не повинен бути від'ємним, введіть ще раз: ");
                rating = int.Parse(Console.ReadLine());
            }

            Random random = new Random();
            int gameIndex = player1.GamesCount;
            int CoinFlip = random.Next(0, 2);
            if (CoinFlip == 0)
            {
                winner = player1.UserName;
                _service.CreateGame(this);
                Console.WriteLine($"\nГравець {player1.UserName} переміг йому випав орел");
                player1.WinGame(this, player1.UserName, player2.UserName, winner, gameIndex);
                Console.WriteLine($"Гравець {player2.UserName} програв йому випала решка");
                player2.LoseGame(this, player1.UserName, player2.UserName, winner, gameIndex);
            }
            else
            {
                winner = player2.UserName;
                _service.CreateGame(this);
                Console.WriteLine($"\nГравець {player1.UserName} переміг йому випав орел");
                player2.WinGame(this, player1.UserName, player2.UserName, winner, gameIndex);
                Console.WriteLine($"Гравець {player2.UserName} програв йому випала решка");
                player1.LoseGame(this, player1.UserName, player2.UserName, winner, gameIndex);
            }
        }
        public virtual int CalculateWinRating(GameAccount player) { return rating; }
        public virtual int CalculateLoseRating(GameAccount player) { return rating; }
    }
}