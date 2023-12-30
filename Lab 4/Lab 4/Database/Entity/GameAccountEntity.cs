using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Database.Entity
{
    internal class GameAccountEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Rating { get; set; }
        public int GamesCount { get; set; }
        public List<GameResultEntity> GameResults { get; set; }
    }
}
