using System;
using System.Threading;
using System.Threading.Tasks;

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


        public void GetGuess(Game game)
        {
            game.AttemptProcessing(new Attempt(this, GetNumber(game)));

            // Will be cycled until the task will be disposed
            // from game.TasksDispose().
            GetGuess(game);
        }

        public abstract int GetNumber(Game game);
    }
}
