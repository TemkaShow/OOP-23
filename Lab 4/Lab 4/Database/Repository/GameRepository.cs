using Lab_4.Database.Entity;
using Lab_4.Database.Repository.Interface;

namespace Lab_4.Database.Repository
{
    internal class GameRepository : IGameRepository
    {
        DbContext _context;

        public GameRepository(DbContext context)
        {
            _context = context;
        }

        public void CreateGame(GameEntity gameEntity)
        {
            gameEntity.Id = _context.Games.Count + 1;
            _context.Games.Add(gameEntity);
        }

        public GameEntity GetGameById(int id)
        {
            return _context.Games.FirstOrDefault(x => x.Id == id);
        }

        public List<GameEntity> GetAllGames()
        {
            return _context.Games;
        }

        public void UpdateGame(GameEntity gameEntity)
        {
            var game = _context.Games.FirstOrDefault(x => x.Id == gameEntity.Id);
            if (game != null)
            {
                game.Player1 = gameEntity.Player1;
                game.Player2 = gameEntity.Player2;
                game.Winner = gameEntity.Winner;
                game.Rating = gameEntity.Rating;
            }
        }

        public void DeleteGame(GameEntity gameEntity)
        {
            var game = _context.Games.FirstOrDefault(x => x.Id == gameEntity.Id);
            if (game != null)
            {
                _context.Games.Remove(game);
            }
        }
    }
}