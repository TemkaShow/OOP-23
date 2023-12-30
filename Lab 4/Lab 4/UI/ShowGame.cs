using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_4.Database.Service;
using Lab_4.Database.Service.Interface;
using Lab_4.UI.Base;

namespace Lab_4.UI
{
    internal class ShowGame : IUserInterface
    {
        GameAccountService _repo;

        public ShowGame(GameAccountService repo)
        {
            _repo = repo;
        }

        public void Action()
        {
            Console.WriteLine("Інформіця про всі зіграні ігри");
            foreach (GameAccount thisPlayer in _repo.GetAllAccounts())
            {
                List<GameResult> games = _repo.GameResults(thisPlayer);

                foreach (GameResult game in games)
                {
                    if (thisPlayer.UserName != game.Player)
                    {
                        Console.WriteLine($"Гра №{game.GameId}. Гравець {game.Player}, зіграв проти {game.Opponent}. Переміг гравець {game.Winner}. Гра була зіграна на {game.Rating} рейтингу");
                    }
                }
            }
        }

        public void DisplayCommandInfo()
        {
            Console.WriteLine("Вивід інформації всіх ігор");
        }
    }
}
