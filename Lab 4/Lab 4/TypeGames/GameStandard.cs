using Lab_4.Database.Service;

namespace Lab_4.TypeGames
{
    class StandardGame : Game
    {
        public StandardGame(GameAccount player1, GameAccount player2, GameService service) : base(player1, player2, service) { }

        public override int CalculateWinRating(GameAccount player)
        {
            return rating;
        }

        public override int CalculateLoseRating(GameAccount player)
        {
            return rating;
        }
    }
}