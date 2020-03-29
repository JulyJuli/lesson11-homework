using System;

namespace Basket_Lib
{
    public abstract class Player
    {
        public string Name { get; protected set; }
        public static int ID { get; protected set; } = 0;
        protected static Random Random = new Random();

        public Player(string name)
        {
            Name = name;
            ID++;
        }

        public abstract int GetGuess(Game game);
    }
}
