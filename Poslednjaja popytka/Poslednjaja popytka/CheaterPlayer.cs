using System;

namespace Poslednjaja_popytka
{
    public class CheaterPlayer : BasePlayer
    {
        public CheaterPlayer()
        {
            TypeOfPlayer = TypeOfPlayer.cheater;
        }

        public override int GuessNumber()
        {
            int countOfGuess;
            int randNumber;

            do
            {
                countOfGuess = 0;
                randNumber = new Random().Next(maxValue: MaxBoundary, minValue: MinBoundary);

                for (int i = 0; i < allGuessedNumbers.Count; i++)
                {
                    if (randNumber == allGuessedNumbers[i])
                    {
                        countOfGuess++;
                    }
                }
            }
            while (countOfGuess != 0);

            allGuessedNumbers.Add(randNumber);

            return randNumber;
        }
    }
}
