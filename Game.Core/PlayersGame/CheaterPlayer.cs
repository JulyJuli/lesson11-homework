using Game.Game;

namespace Game.PlayersGame
{
    public class CheaterPlayer : Players
    {
        public CheaterPlayer(string name) : base(name)
        { }

        public override int Guess()
        {
            this.Sleep();

            int result;
            do
            {
                result = PrintGuess();
            }
            while (GameClass.GuessedNumbers.Contains(result));
            Answers.Add(result);
            return result;
        }
    }
}