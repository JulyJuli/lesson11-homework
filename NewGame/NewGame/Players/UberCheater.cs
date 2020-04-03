
namespace NewGame.Players
{
    public class UberCheaterPlayer : BasePlayer
    {
        private int currentGuess = MinBoundary;
        public UberCheaterPlayer()
        {
            TypeOfPlayer = TypeOfPlayer.uberCheater;
        }

        public override int GuessNumber(int i)
        {
            while (allGuessedNumbers.Contains(currentGuess))
            {
                currentGuess++;
            }

            allGuessedNumbers.Add(currentGuess);

            return currentGuess;
        }
    }
}
