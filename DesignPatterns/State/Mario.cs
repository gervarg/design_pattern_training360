using System;
using static System.Console;

namespace State
{
    // https://www.c-sharpcorner.com/article/understanding-state-design-pattern-by-implementing-finite-state/

    public interface IMarioState
    {
        void GotMushroom();
        void GotFireFlower();
        void GotFeather();
        void MetMonster();
    };

    public class SmallMario : IMarioState
    {
        private Mario mario;

        public SmallMario(Mario mario)
        {
            this.mario = mario;
        }

        public void GotMushroom()
        {
            WriteLine("Got Mushroom!");
            mario.state = mario.GetState("superMario");
            mario.GotCoins(100);
        }

        public void GotFireFlower()
        {
            WriteLine("Got FireFlower!");
            mario.state = mario.GetState("fireMario");
            mario.GotCoins(200);
        }

        public void GotFeather()
        {
            WriteLine("Got Feather!");
            mario.state = mario.GetState("capeMario");
            mario.GotCoins(300);
        }

        public void MetMonster()
        {
            WriteLine("Met Monster!");
            mario.state = mario.GetState("smallMario");
            mario.LostLife();
        }
    }

    public class SuperMario : IMarioState
    {
        private Mario mario;

        public SuperMario(Mario mario)
        {
            this.mario = mario;
        }

        public void GotMushroom()
        {
            WriteLine("Got Mushroom!");
            mario.GotCoins(100);
        }

        public void GotFireFlower()
        {
            WriteLine("Got FireFlower!");
            mario.state = mario.GetState("fireMario");
            mario.GotCoins(200);
        }

        public void GotFeather()
        {
            WriteLine("Got Feather!");
            mario.state = mario.GetState("capeMario");
            mario.GotCoins(300);
        }

        public void MetMonster()
        {
            WriteLine("Met Monster!");
            mario.state = mario.GetState("smallMario");
        }
    }

    public class FireMario : IMarioState
    {
        private Mario mario;

        public FireMario(Mario mario)
        {
            this.mario = mario;
        }

        public void GotMushroom()
        {
            WriteLine("Got Mushroom!");
            mario.GotCoins(100);
        }

        public void GotFireFlower()
        {
            WriteLine("Got FireFlower!");
            mario.GotCoins(200);
        }

        public void GotFeather()
        {
            WriteLine("Got Feather!");
            mario.state = mario.GetState("capeMario");
            mario.GotCoins(300);
        }

        public void MetMonster()
        {
            WriteLine("Met Monster!");
            mario.state = mario.GetState("smallMario");
        }
    }

    public class CapeMario : IMarioState
    {
        private Mario mario;

        public CapeMario(Mario mario)
        {
            this.mario = mario;
        }

        public void GotMushroom()
        {
            WriteLine("Got Mushroom!");
            mario.GotCoins(100);
        }

        public void GotFireFlower()
        {
            WriteLine("Got FireFlower!");
            mario.state = mario.GetState("fireMario");
            mario.GotCoins(200);
        }

        public void GotFeather()
        {
            WriteLine("Got Feather!");
            mario.GotCoins(300);
        }

        public void MetMonster()
        {
            WriteLine("Met Monster!");
            mario.state = mario.GetState("smallMario");
        }
    }

    public class Mario
    {
        public int LifeCount { get; private set; }
        public int CoinCount { get; private set; }

        public IMarioState state;

        private SmallMario smallMario;
        private SuperMario superMario;
        private FireMario fireMario;
        private CapeMario capeMario;

        public Mario()
        {
            LifeCount = 1;
            CoinCount = 0;

            smallMario = new SmallMario(this);
            superMario = new SuperMario(this);
            fireMario = new FireMario(this);
            capeMario = new CapeMario(this);

            state = smallMario;
        }

        public IMarioState GetState(string stateId)
        {
            switch (stateId)
            {
                case "smallMario":
                    return smallMario;
                case "superMario":
                    return superMario;
                case "fireMario":
                    return fireMario;
                case "capeMario":
                    return capeMario;
                default:
                    return null;
            }
        }

        public void GotMushroom()
        {
            state.GotMushroom();
        }

        public void GotFireFlower()
        {
            state.GotFireFlower();
        }

        public void GotFeather()
        {
            state.GotFeather();
        }

        public void MetMonster()
        {
            state.MetMonster();
        }

        public void GotCoins(int numberOfCoins)
        {
            WriteLine($"Got {numberOfCoins} Coin(s)!");
            CoinCount += numberOfCoins;
            if (CoinCount >= 5000)
            {
                GotLife();
                CoinCount -= 5000;
            }
        }

        public void GotLife()
        {
            WriteLine("Got Life!");
            LifeCount += 1;
        }

        public void LostLife()
        {
            WriteLine("Lost Life!");
            LifeCount -= 1;
            if (LifeCount <= 0)
                GameOver();
        }

        public void GameOver()
        {
            LifeCount = 0;
            CoinCount = 0;
            WriteLine("Game Over!");
        }

        public override string ToString()
        {
            return $"State: {state} | LifeCount: {LifeCount} | CoinsCount: {CoinCount} {Environment.NewLine}";
        }
    }
}
