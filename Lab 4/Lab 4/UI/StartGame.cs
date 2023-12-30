using Lab_4.Database.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_4.UI.Base;

namespace Lab_4.UI
{
    internal class StartGame : IUserInterface
    {
        GameAccountService _repo;
        GameService _repoGame;

        public StartGame(GameAccountService repo, GameService repoGame)
        {
            _repo = repo;
            _repoGame = repoGame;
        }
        public void Action()
        {
            if (_repo.GetAllAccounts().Count <= 1)
            {
                Console.WriteLine("Недостатньо гравців для початку гри. Додайте ще гравців.");
                return;
            }
            GameAccount player1;
            GameAccount player2;

            Console.WriteLine("Виберіть граців які будуть грати ввівши їх ID");
            int player1ID = int.Parse(Console.ReadLine());
            int player2ID = int.Parse(Console.ReadLine());

            player1 = _repo.GetAccountById(player1ID);
            player2 = _repo.GetAccountById(player2ID);

            string answer;
            do
            {
                Game game = GameType(player1, player2, _repoGame);
                game.PlayGame(player1, player2);
                Console.WriteLine("Хочете зіграти знову? Введіть (y)");
                answer = Console.ReadLine();
            } while (answer.ToLower() == "y");
        }
        private Game GameType(GameAccount player1, GameAccount player2, GameService service)
        {
            Console.WriteLine("\nВиберіть тип гри: \n1. Стандартна гра \n2. Тренувальна гра \n3. Потрійна гра");
            int choose = int.Parse(Console.ReadLine());
            GameFactory factory = new GameFactory();
            switch (choose)
            {
                case 1:
                    return factory.CreateStandardGame(player1, player2, service);
                case 2:
                    return factory.CreateTrainingGame(player1, player2, service);
                case 3:
                    return factory.CreateTriplePlayerGame(player1, player2, service);
                default:
                    Console.WriteLine("Неправильний вибір. Повернення до стандартної гри.");
                    return factory.CreateStandardGame(player1, player2, service);
            }
        }

        public void DisplayCommandInfo()
        {
            Console.WriteLine("Розпочати гру");
        }
    }
}
