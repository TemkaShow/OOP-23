using Lab_4.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Database.Repository.Interface
{
    internal interface IGameRepository
    {
        public void CreateGame(GameEntity gameEntity);
        public GameEntity GetGameById(int id);
        public List<GameEntity> GetAllGames();
        public void UpdateGame(GameEntity gameEntity);
        public void DeleteGame(GameEntity gameEntity);
        
    }
}
