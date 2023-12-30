using Lab_4.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Database.Service.Interface
{
    internal interface IGameService
    {
       public void CreateGame(Game gameEntity);
       public void UpdateGame(Game gameEntity);
       public void DeleteGame(Game gameEntity);


    }
}
