using Lab_4.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Database.Service.Interface
{
    internal interface IGameAccountService
    {
        public void CreateAccount(GameAccount accountEntity);
        public void UpdateAccount(GameAccount accountEntity);
        public void DeleteAccount(GameAccount accountEntity);
        public List<GameAccount> GetAllAccounts();
        public GameAccount GetAccountById(int id);
        public List<GameResult> GameResults(GameAccount accountEntity);
        public void AddGameResult(GameResult gameResult, GameAccount accountEntity);
    }
}
