using System;
using System.Collections.Generic;
using System.Linq;
using Lab_4.Database.Service;
using Lab_4.UI.Base;

namespace Lab_4.UI
{
    internal class ShowAccount : IUserInterface
    {
        GameAccountService _repo;

        public ShowAccount(GameAccountService repo)
        {
            _repo = repo;
        }

        public void Action()
        {
            var players = _repo.GetAllAccounts().Distinct();
            foreach (var player in players)
            {
                Console.WriteLine($"ID Гравця: {player.Id}, Ім'я: {player.UserName}, Рейтинг: {player.CurrentRating}");
            }
        }

        public void DisplayCommandInfo()
        {
            Console.WriteLine("Вивід списку гравців");
        }
    }
}