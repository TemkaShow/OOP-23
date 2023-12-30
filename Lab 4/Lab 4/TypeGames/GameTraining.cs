using Lab_4.Database.Service;

namespace Lab_4.TypeGames
{
    class TrainingGame : Game
    {
        public TrainingGame(GameAccount player1, GameAccount player2, GameService service) : base(player1, player2, service) { }

        public override int CalculateWinRating(GameAccount player)
        {
            return 0;
        }

        public override int CalculateLoseRating(GameAccount player)
        {
            return 0;
        }
    }
}