using Lab_4.Database.Entity;
using Lab_4.Database.Service.Interface;
using System.Collections.Generic;
using Lab_4.Database.Repository;

namespace Lab_4.Database.Service
{
    internal class GameService : IGameService
    {
        GameRepository _repo;

        public GameService(DbContext context)
        {
            _repo = new GameRepository(context);

        }

        public void CreateGame(Game game)
        {
            var gameEntity = MapToEntity(game);
            _repo.CreateGame(gameEntity);
        }

        public void UpdateGame(Game game)
        {
            var gameEntity = MapToEntity(game);
            _repo.UpdateGame(gameEntity);
        }
        
        public void DeleteGame(Game game)
        {
            var gameEntity = MapToEntity(game);
            _repo.DeleteGame(gameEntity);
        }

        private GameEntity MapToEntity(Game game)
        {
            return new GameEntity
            {
                Player1 = game.player1,
                Player2 = game.player2,
                Winner = game.winner,
                Rating = game.rating
            };
        }
    }
}