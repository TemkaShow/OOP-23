using Lab_4.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Database.Repository.Interface
{
    internal interface IGameAccountRepository
    {
       public void CreateAccount(GameAccountEntity accountEntity);
       public GameAccountEntity GetAccountById(int id);
       public List<GameAccountEntity> GetAllAccounts();
       public void UpdateAccount(GameAccountEntity accountEntity);
       public void DeleteAccount(GameAccountEntity accountEntity);
       public List<GameResultEntity> GameResults(GameAccountEntity accountEntity);
       public void AddGameResult(GameResultEntity gameResult, GameAccountEntity accountEntity);
    }
}
