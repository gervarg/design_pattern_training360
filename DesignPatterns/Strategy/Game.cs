using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    class Game
    {
        private readonly IGameDifficulty gameDifficulty;

        public Game()
        {
            this.gameDifficulty = new BasicGameDifficulty();
        }

        public Game(IGameDifficulty gameDifficulty)
        {
            this.gameDifficulty = gameDifficulty;
        }

        public void SetGameDifficulty()
        {
            gameDifficulty.SetGameDifficulty();
        }
    }

    internal class BasicGameDifficulty : IGameDifficulty
    {
        public void SetGameDifficulty()
        {
            Console.WriteLine("Game Difficulty set to Basic.");
        }
    }

    internal interface IGameDifficulty
    {
        void SetGameDifficulty();
    }

    class ModerateGameDifficulty : IGameDifficulty
    {
        public void SetGameDifficulty()
        {
            Console.WriteLine("Game Difficulty set to Moderate.");
        }
    }

    class HardGameDifficulty : IGameDifficulty
    {
        public void SetGameDifficulty()
        {
            Console.WriteLine("Game Difficulty set to Hard.");
        }
    }


}
