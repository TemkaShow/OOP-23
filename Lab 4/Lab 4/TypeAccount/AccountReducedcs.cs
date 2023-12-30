using Lab_4.Database.Service;

namespace Lab_4.TypeAccount
{
    class ReducedPointsGameAccount : GameAccount
    {
        public ReducedPointsGameAccount(GameAccountService service, int Id, string userName, int gamesCount = 0) : base(service, Id, userName, gamesCount) { }

        public override int CalculatePoints(int gameRating)
        {
            return gameRating / 2;
        }
    }
}