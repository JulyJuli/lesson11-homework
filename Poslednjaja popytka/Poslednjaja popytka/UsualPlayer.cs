using System;

namespace Poslednjaja_popytka
{
    public class UsualPlayer : BasePlayer
    {
        public UsualPlayer()
        {
            TypeOfPlayer = TypeOfPlayer.usual;
        }

        public override int GuessNumber()
        {
            var randNumber = new Random().Next(maxValue: MaxBoundary, minValue: MinBoundary);
            allGuessedNumbers.Add(randNumber);
            return randNumber;
        }
    }
}
