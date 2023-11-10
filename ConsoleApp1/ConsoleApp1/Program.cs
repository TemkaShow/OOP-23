using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Text;

class GameAccount
{
    public string UserName { get; set; }
    public int CurrentRating { get; set; }
    public int GamesCount { get; set; }
    public List<GameResult> GameResults { get; set; } = new List<GameResult>();


    public void WinGame(int rating, string player, string opponent, string winner, int gameID)
    {
        GamesCount++;
        CurrentRating += rating;
        GameResults.Add(new GameResult(player, opponent, winner, rating, gameID));
    }

    public void LoseGame(int rating, string player, string opponent, string winner, int gameID)
    {
        GamesCount++;
        CurrentRating -= rating;
        if (CurrentRating < 1)
        {
            CurrentRating = 1;
        }
        GameResults.Add(new GameResult(player, opponent, winner, rating, gameID));
    }

    public void GetStats()
    {
        foreach (GameResult result in GameResults)
        {
            Console.WriteLine($"\nГра #{result.GameID}, гравець {result.Winner} переміг, гра була зіграна на {result.Rating} рейтингу");
        }
    }
}
class Game
{
    public static int gameCounter = 0;

    public void PlayGame(List<GameAccount> players, int rating)
    {
        Random random = new();
        int CoinFlip = random.Next(2);

        GameAccount winner = players[CoinFlip];
        GameAccount loser = players[1 - CoinFlip];

        Console.WriteLine($"\nГравець {winner.UserName} переміг йому випав орел");
        winner.WinGame(rating, winner.UserName, winner.UserName, winner.UserName, gameCounter);
        Console.WriteLine($"Гравець {loser.UserName} програв йому випала решка");
        loser.LoseGame(rating, loser.UserName, winner.UserName, winner.UserName, gameCounter);

        Console.WriteLine($"\nПоточний рейтинг гравця {winner.UserName}: {winner.CurrentRating}");
        Console.WriteLine($"Поточний рейтинг гравця {loser.UserName}: {loser.CurrentRating}");

        gameCounter++;
    }
}

class GameResult(string player, string opponent, string winner, int rating, int gameID)
{
    public string Player { get; } = player;
    public string Opponent { get; } = opponent;
    public string Winner { get; } = winner;
    public int Rating { get; } = rating;
    public int GameID { get; } = gameID;
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        int rating;
        string answer;

        List<GameAccount> players = new List<GameAccount>();

        for (int i = 1; i <= 2; i++)
        {
            GameAccount player = new GameAccount();
            Console.Write($"Введіть ім'я гравця {i}: ");
            player.UserName = Console.ReadLine();
            player.CurrentRating = 150;
            players.Add(player);
        }


        do
        {
            Console.Write("\nВведіть рейтинг, на який ви граєте: ");
            rating = int.Parse(Console.ReadLine());
            while (rating <= 0)
            {
                Console.Write("\nРейтинг не повинен бути від'ємним, введіть ще раз: ");
                rating = int.Parse(Console.ReadLine());
            }

            Game game = new();
            game.PlayGame(players, rating);

            Console.Write("\nХочете зіграти знову? Введіть (так): ");
            answer = Console.ReadLine();
        } while (answer.ToLower() == "так");

        players[0].GetStats();
    }
}