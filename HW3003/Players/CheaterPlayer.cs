using HW3003.Players;

namespace HW3003
{
    public class CheaterPlayer : Player
    {
        protected override string PlayerType => "Cheater Player";
        int index = 0;
        public override int GuessingGame()
        {
            var randNumber = SequenceRandomNumber[index++];
            var counter = 1;

            while (allGuessings.Contains(randNumber))
            {
                if (counter < 6)
                {
                    counter++;
                    randNumber = SequenceRandomNumber[index++];
                }
            }
            
            allGuessings.Add(randNumber);
            return randNumber;
        }
    }

}
