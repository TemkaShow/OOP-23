using Lab_4.Database.Service;
using System;
using System.Collections.Generic;

namespace Lab_4
{
    internal class GameAccount
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        public List<GameResult> GameResults { get; set; } = new List<GameResult>();
        public GameAccountService _service { get; set; }

        public GameAccount(GameAccountService service, int ID, string userName, int gamesCount = 0)
        {
            _service = service;
            UserName = userName;
            CurrentRating = 150;
            GamesCount = gamesCount;
            Id = ID;
        }
        
        public virtual void WinGame(Game game, string player1, string player2, string winner, int gameIndex)
        {
            GamesCount++;
            int gameRating = CalculatePoints(game.CalculateWinRating(this));
            CurrentRating += gameRating;
            GameResults.Add(new GameResult(player1, player2, winner, gameRating, gameIndex));
            _service.UpdateAccount(this);
            Console.WriteLine($"\nІм'я гравця: {UserName}\nПоточний рейтинг: {CurrentRating} \nІгор зіграно: {GamesCount}\n");
        }
        public virtual void LoseGame(Game game, string player1, string player2, string winner, int gameIndex)
        {
            GamesCount++;
            int gameRating = CalculatePoints(game.CalculateLoseRating(this));
            CurrentRating -= gameRating;
            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }
            GameResults.Add(new GameResult(player1, player2, winner, gameRating, gameIndex));
            _service.UpdateAccount(this);
            Console.WriteLine($"\nІм'я гравця: {UserName}\nПоточний рейтинг: {CurrentRating} \nІгор зіграно: {GamesCount}\n");
        }
        
        public virtual int CalculatePoints(int gameRating)
        {
            return gameRating;
        }
    }
}