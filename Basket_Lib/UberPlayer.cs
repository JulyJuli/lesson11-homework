namespace Basket_Lib
{
    public class UberPlayer : Player
    {
        private int? CurrentAttemptNumber { get; set; } = null;

        public UberPlayer(string name) : base(name) { }

        public override int GetGuess(Game game)
        {
            if (!CurrentAttemptNumber.HasValue)
            {
                CurrentAttemptNumber = game.MinBasketWeight;
            }
            game.AttemptList.Add(new Attempt(this, (int)CurrentAttemptNumber));
            return (int)CurrentAttemptNumber++;
        }
    }
}
