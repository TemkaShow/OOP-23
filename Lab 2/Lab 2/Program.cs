using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Lab_2.TypeAccount;

namespace Lab_2
{
    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int rating;
            string answer;

            List<GameAccount> players = new List<GameAccount>();

            for (int i = 1; i <= 2; i++)
            {
                Console.WriteLine($"Виберіть тип акаунту для гравця {i}:\n1. Стандартний\n2. Вдвоє менше рейтингу\n3. Додатковий рейтинг");
                int accountTypeChoice = int.Parse(Console.ReadLine());

                GameAccount player;

                switch (accountTypeChoice)
                {
                    case 1:
                        player = new StandardGameAccount();
                        break;
                    case 2:
                        player = new ReducedPointsGameAccount();
                        break;
                    case 3:
                        player = new BonusPointsGameAccount();
                        break;
                    default:
                        Console.WriteLine("Неправильне значення. Обрано стандартний акаунт.");
                        player = new StandardGameAccount();
                        break;
                }

                Console.Write($"Введіть ім'я гравця {i}: ");
                player.UserName = Console.ReadLine();
                player.CurrentRating = 150;
                players.Add(player);
            }

            do
            {
                Console.WriteLine("\nВиберіть тип гри:");
                Console.WriteLine("1. Стандартна гра");
                Console.WriteLine("2. Тренувальна гра");
                Console.WriteLine("3. Потрійна гра");

                int choice = int.Parse(Console.ReadLine());
                Game game;

                GameFactory factory = new GameFactory();

                switch (choice)
                {
                    case 1:
                        game = factory.CreateStandardGame();
                        break;

                    case 2:
                        game = factory.CreateTrainingGame();
                        break;

                    case 3:
                        game = factory.CreateTriplePlayerGame();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Defaulting to standard game.");
                        game = factory.CreateStandardGame();
                        break;
                }

                Console.Write("\nВведіть рейтинг, на який ви граєте: ");
                rating = int.Parse(Console.ReadLine());
                while (rating <= 0)
                {
                    Console.Write("\nРейтинг не повинен бути від'ємним, введіть ще раз: ");
                    rating = int.Parse(Console.ReadLine());
                }

                game.PlayGame(players, rating);

                Console.Write("\nХочете зіграти знову? Введіть (так): ");
                answer = Console.ReadLine();
            } while (answer.ToLower() == "y");

            players[0].GetStats();
        }
    }
}
