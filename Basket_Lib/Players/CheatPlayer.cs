using System;
using System.Linq;

namespace Basket_Lib
{
    public class CheatPlayer : Player
    {
        public CheatPlayer(string name) : base(name) { }


        public override int GetNumber(Game game)
        {
            int result = Random.Next(game.MinBasketWeight, game.MaxBasketWeight + 1);

            var cheatList = game.AttemptList.Select(i => i.ChosedNumber).ToList();

            if (!cheatList.Contains(result))
            {
                return result;
            }
            return GetNumber(game);
        }
    }
}
