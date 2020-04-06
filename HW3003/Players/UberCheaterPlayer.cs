using HW3003.Players;

namespace HW3003
{
    public class UberCheaterPlayer : Player
    {        
        int index = 0;
        protected override string PlayerType => "Uber Cheater";

        public override int GuessingGame()
        {
            var counter = 1;

            while (allGuessings.Contains(SequenceNumber[index]))
            {
                if (counter < 6)
                {
                    counter++;
                    index++;
                }
            }

            allGuessings.Add(SequenceNumber[index]);

            return SequenceNumber[index];
        }
    }
}
