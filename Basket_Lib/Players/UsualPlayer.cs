using System;

namespace Basket_Lib
{
    public class UsualPlayer : Player
    {
        public UsualPlayer(string name) : base(name) { }

        public override int GetNumber(Game game)
        {
            return Random.Next(game.MinBasketWeight, game.MaxBasketWeight + 1);
        }
    }   
}
