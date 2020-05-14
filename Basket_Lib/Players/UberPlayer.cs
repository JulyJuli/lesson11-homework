namespace Basket_Lib
{
    public class UberPlayer : Player
    {
        private int? CurrentAttemptNumber { get; set; } = null;


        public UberPlayer(string name) : base(name) { }


        public override int GetNumber(Game game)
        {
            if (!CurrentAttemptNumber.HasValue)
            {
                CurrentAttemptNumber = game.MinBasketWeight;
            }
            return (int)CurrentAttemptNumber++;
        }
    }
}
