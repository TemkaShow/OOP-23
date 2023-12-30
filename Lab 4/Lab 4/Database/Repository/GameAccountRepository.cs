using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_4.Database.Entity;
using Lab_4.Database.Repository.Interface;

namespace Lab_4.Database.Repository
{
    internal class GameAccountRepository : IGameAccountRepository
    {
        DbContext _context;

        public GameAccountRepository(DbContext context)
        {
            _context = context;
        }

        public void CreateAccount(GameAccountEntity accountEntity)
        {
            _context.Accounts.Add(accountEntity);
        }

        public GameAccountEntity GetAccountById(int id)
        {
            return _context.Accounts.FirstOrDefault(x => x.Id == id);
        }

        public List<GameAccountEntity> GetAllAccounts()
        {
            return _context.Accounts;
        }

        public void UpdateAccount(GameAccountEntity accountEntity)
        {
            _context.Accounts.RemoveAt(accountEntity.Id);
            _context.Accounts.Insert(accountEntity.Id, accountEntity);
        }

        public void DeleteAccount(GameAccountEntity accountEntity)
        {
            var account = _context.Accounts.FirstOrDefault(x => x.Id == accountEntity.Id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }
        }
        public List<GameResultEntity> GameResults(GameAccountEntity entity)
        {
            return entity.GameResults;
        }

        public void AddGameResult(GameResultEntity gameResult, GameAccountEntity entity)
        {
            _context.Accounts[entity.Id].GameResults.Add(gameResult);
        }
    }
}