namespace Game.PlayersGame
{
    public class RandomPlayer : Players
    {
        public RandomPlayer(string name) : base(name)
        { }
        public override int Guess()
        {
            this.Sleep();

            int result = PrintGuess();
            Answers.Add(result);
            return result;
        }
    }
}