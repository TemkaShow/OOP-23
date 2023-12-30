using Lab_4.Database.Service;
using Lab_4.TypeGames;

namespace Lab_4
{
    internal class GameFactory
    {
        public Game CreateStandardGame(GameAccount player1, GameAccount player2, GameService service)
        {
            return new StandardGame(player1, player2, service);
        }
        public Game CreateTrainingGame(GameAccount player1, GameAccount player2, GameService service)
        {
            return new TrainingGame(player1, player2, service);
        }
        public Game CreateTriplePlayerGame(GameAccount player1, GameAccount player2, GameService service)
        {
            return new TripleGame(player1, player2, service);
        }
    }
}