
namespace Poslednjaja_popytka
{
    public class UberCheaterPlayer : BasePlayer
    {
        private int currentGuess = MinBoundary;
        public UberCheaterPlayer()
        {
            TypeOfPlayer = TypeOfPlayer.uberCheater;
        }

        public override int GuessNumber()
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
