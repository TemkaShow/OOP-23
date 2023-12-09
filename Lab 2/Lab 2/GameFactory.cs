using Lab_2.TypeGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class GameFactory
    {
        public Game CreateStandardGame()
        {
            return new StandardGame();
        }

        public Game CreateTrainingGame()
        {
            return new TrainingGame();
        }

        public Game CreateTriplePlayerGame()
        {
            return new TripleGame();
        }
    }
}
    