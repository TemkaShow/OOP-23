using Lab_4.Database.Service;
using Lab_4.TypeAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using Lab_4.UI.Base;

namespace Lab_4.UI
{
    internal class AddAccounts : IUserInterface
    {
        GameAccountService _repo;

        public AddAccounts(GameAccountService repo)
        {
            _repo = repo;
        }

        public void Action()
        {
            Console.WriteLine("Введіть ім'я гравця: ");
            string gameName = Console.ReadLine();
            GameAccount player = AccountChose(_repo, gameName);
            _repo.CreateAccount(player);
        }

        private GameAccount AccountChose(GameAccountService service, string userName)
        {
            Console.WriteLine("Виберіть тип акаунту: \n1. Стандартний\n2. Вдвоє менше рейтингу\n3. Додатковий рейтинг");
            int choose = int.Parse(Console.ReadLine());
            var Id = service.GetAllAccounts().Count();
            GameAccount standartGameAccount = new StandardGameAccount(service, Id, userName);

            switch (choose)
            {
                case 1:
                    return standartGameAccount;
                case 2:
                    var halfGameAccount = new ReducedPointsGameAccount(service, Id, userName);
                    return halfGameAccount;
                case 3:
                    var bonusGameAccount = new BonusPointsGameAccount(service, Id, userName);
                    return bonusGameAccount;
                default:
                    Console.WriteLine("Неправильне значення. Обрано стандартний акаунт.");
                    return standartGameAccount;
            }
        }

        public void DisplayCommandInfo()
        {
            Console.WriteLine("Додати гравця");
        }
    }
}
