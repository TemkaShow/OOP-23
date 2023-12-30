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
    internal class ShowSpecificAccount : IUserInterface
    {
        GameAccountService _service;

        public ShowSpecificAccount(GameAccountService service)
        {
            _service = service;
        }

        public void Action()
        {
            Console.WriteLine("Ввдедіть ID гравця щоб побачити його статистику");
            int playerID = int.Parse(Console.ReadLine());
            GameAccount player = _service.GetAccountById(playerID);
            Console.WriteLine($"Інформація про ігри гравця {player.UserName}:");
            List<GameResult> games = _service.GameResults(player);
            foreach (GameResult game in games)
            {
                Console.WriteLine($"Гра №{game.GameId}. Гравець {game.Player}, зіграв проти {game.Opponent}. Переміг гравець {game.Winner}. Гра була зіграна на {game.Rating} рейтингу");
            }
        }

        public void DisplayCommandInfo()
        {
            Console.WriteLine("Вивід інформації про ігри гравця ID");
        }
    }
}
