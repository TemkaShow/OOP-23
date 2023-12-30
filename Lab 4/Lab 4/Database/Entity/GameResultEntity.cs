using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Database.Entity
{
    internal class GameResultEntity
    {
        public string Player { get; set; }
        public string Opponent { get; set; }
        public string Winner { get; set; }
        public int Rating { get; set; }
        public int GameId { get; set; }
    }
}
