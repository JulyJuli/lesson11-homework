using System.Linq;

namespace Basket_Lib
{
    public class UberCheatPlayer : Player
    {
        private int? CurrentAttemptNumber { get; set; } = null;
        public UberCheatPlayer(string name) : base(name) { }


        public override int GetNumber(Game game)
        {
            var cheatList = game.AttemptList.Select(i => i.ChosedNumber).ToList();

            if (!CurrentAttemptNumber.HasValue)
            {
                CurrentAttemptNumber = game.MinBasketWeight;
            }

            if (!cheatList.Contains((int)CurrentAttemptNumber))
            {
                return (int)CurrentAttemptNumber++;
            }
            CurrentAttemptNumber++;
            return GetNumber(game);
        }
    }
}
