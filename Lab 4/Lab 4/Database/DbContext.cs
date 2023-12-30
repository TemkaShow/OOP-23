using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Lab_4.Database.Entity;

namespace Lab_4.Database
{
    internal class DbContext
    {
        public List<GameAccountEntity> Accounts { get; set; } = new List<GameAccountEntity>();
        public List<GameEntity> Games { get; set; } = new List<GameEntity>();
        public List<GameResultEntity> Results { get; set; } = new List<GameResultEntity>();
    }
}
