using Lab_4.Database.Service;

namespace Lab_4.TypeAccount
{
    class BonusPointsGameAccount : GameAccount
    {
        private int consecutiveWins = 0;

        public BonusPointsGameAccount(GameAccountService service, int Id, string userName, int gamesCount = 0) : base(service, Id, userName, gamesCount) { }

        public override int CalculatePoints(int gameRating)
        {
            if (consecutiveWins >= 1)
            {
                return gameRating + 20;
            }

            consecutiveWins++;
            return gameRating;
        }
        public override void LoseGame(Game game, string player1, string player2, string winner, int gameIndex)
        {
            base.LoseGame(game, player1, player2, winner, gameIndex);
            consecutiveWins = 0;
        }
    }
}