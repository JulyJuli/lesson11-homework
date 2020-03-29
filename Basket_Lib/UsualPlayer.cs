using System;

namespace Basket_Lib
{
    public class UsualPlayer : Player
    {
        public UsualPlayer(string name) : base(name) { }

        public override int GetGuess(Game game)
        {
            int result = Random.Next(game.MinBasketWeight, game.MaxBasketWeight + 1);
            game.AttemptList.Add(new Attempt(this, result));
            return result;
        }
    }
}
