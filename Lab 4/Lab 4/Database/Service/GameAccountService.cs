using Lab_4.Database.Entity;
using Lab_4.Database.Repository;
using Lab_4.Database.Service.Interface;
using Lab_4.Database;
using Lab_4;
using System.Collections.Generic;
using System.Linq;

namespace Lab_4.Database.Service
{
    internal class GameAccountService : IGameAccountService
    {
        GameAccountRepository _repo;

        public GameAccountService(DbContext context)
        {
            _repo = new GameAccountRepository(context);
        }

        public void CreateAccount(GameAccount account)
        {
            var accountEntity = MapToEntity(account);
            _repo.CreateAccount(accountEntity);
        }

        public void DeleteAccount(GameAccount account)
        {
            var accountEntity = MapToEntity(account);
            _repo.DeleteAccount(accountEntity);
        }

        public GameAccount GetAccountById(int id)
        {
            var accountEntity = _repo.GetAccountById(id);
            return MapToDomain(accountEntity); 
        }

        public List<GameAccount> GetAllAccounts()
        {
            return _repo.GetAllAccounts().Select(x => x != null ? MapToDomain(x) : null).ToList();
        }

        public void UpdateAccount(GameAccount account)
        {
            _repo.UpdateAccount(MapToEntity(account));
        }

        public List<GameResult> GameResults(GameAccount entity)
        {
            return MapGameResultList(_repo.GameResults(MapToEntity(entity)));
        }

        public void AddGameResult(GameResult gameResult, GameAccount entity)
        {
            _repo.AddGameResult(MapGameResult(gameResult), MapToEntity(entity));
        }

        private GameAccount MapToDomain(GameAccountEntity accountEntity)
        {
            return new GameAccount(this, accountEntity.Id, accountEntity.UserName)
            {
                _service = this,
                UserName = accountEntity.UserName,
                CurrentRating = accountEntity.Rating,
                GamesCount = accountEntity.GamesCount,
                GameResults = MapGameResultList(accountEntity.GameResults)
            };
        }

        private GameAccountEntity MapToEntity(GameAccount account)
        {
            return new GameAccountEntity
            {
                Id = account.Id,
                UserName = account.UserName,
                Rating = account.CurrentRating,
                GamesCount = account.GamesCount,
                GameResults = MapGameResultList(account.GameResults)
            };
        }
        private List<GameResultEntity> MapGameResultList(List<GameResult> gameResultList)
        {
            if (gameResultList == null)
            {
                return null;
            }

            List<GameResultEntity> gameResultEntitieList = new List<GameResultEntity>();

            foreach (var gameResult in gameResultList)
            {
                gameResultEntitieList.Add(new GameResultEntity
                {
                    Player = gameResult.Player,
                    Opponent = gameResult.Opponent,
                    Winner = gameResult.Winner,
                    Rating = gameResult.Rating,
                    GameId = gameResult.GameId
                });
            }
            return gameResultEntitieList;
        }
        private List<GameResult> MapGameResultList(List<GameResultEntity> gameResultEntitieList)
        {
            List<GameResult> gameResultList = new List<GameResult>();
            if (gameResultEntitieList == null)
            {
                return new List<GameResult>();
            }
            foreach (var gameResultEntity in gameResultEntitieList)
            {
                gameResultList.Add(new GameResult
                {
                    Player = gameResultEntity.Player,
                    Opponent = gameResultEntity.Opponent,
                    Winner = gameResultEntity.Winner,
                    Rating = gameResultEntity.Rating,
                    GameId = gameResultEntity.GameId
                });
            }
            return gameResultList;
        }

        

        private GameResultEntity MapGameResult(GameResult gameResult)
        {
            if (gameResult == null)
            {
                return null;
            }

            return new GameResultEntity
            {
                Player = gameResult.Player,
                Opponent = gameResult.Opponent,
                Winner = gameResult.Winner,
                Rating = gameResult.Rating,
                GameId = gameResult.GameId
            };
        }
    }
}
