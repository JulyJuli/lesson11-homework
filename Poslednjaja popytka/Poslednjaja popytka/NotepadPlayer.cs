using System;
using System.Collections.Generic;

namespace Poslednjaja_popytka
{
    public class NotepadPlayer : BasePlayer
    {
        private readonly List<int> passedGuessings;

        public NotepadPlayer()
        {
            TypeOfPlayer = TypeOfPlayer.notepad;
            passedGuessings = new List<int>();
        }

        public override int GuessNumber()
        {
            int countOfGuess;
            int randNumber;

            do
            {
                countOfGuess = 0;
                randNumber = new Random().Next(maxValue: MaxBoundary, minValue: MinBoundary);

                for (int i = 0; i < passedGuessings.Count; i++)
                {
                    if (randNumber == passedGuessings[i])
                    {
                        countOfGuess++;
                    }
                }
            }
            while (countOfGuess != 0);

            passedGuessings.Add(randNumber);
            allGuessedNumbers.Add(randNumber);

            return randNumber;
        }
    }
}
