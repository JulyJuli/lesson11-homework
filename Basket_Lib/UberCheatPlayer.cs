using System.Linq;

namespace Basket_Lib
{
    public class UberCheatPlayer : Player
    {
        private int? CurrentAttemptNumber { get; set; } = null;

        public UberCheatPlayer(string name) : base(name) { }

        public override int GetGuess(Game game)
        {
            if (!CurrentAttemptNumber.HasValue)
            {
                CurrentAttemptNumber = game.MinBasketWeight;
            }

            var cheatList = game.AttemptList.Select(i => i.ChosedNumber).ToList();

            if (!cheatList.Contains((int)CurrentAttemptNumber))
            {
                game.AttemptList.Add(new Attempt(this, (int)CurrentAttemptNumber));
                return (int)CurrentAttemptNumber++;
            }
            CurrentAttemptNumber++;
            return GetGuess(game);
        }
    }
}
