using HW3003.Players;

namespace HW3003
{
    public class UberPlayer : Player
    {      

        int index = 0;
        protected override string PlayerType => "UberPlayer";

        public override int GuessingGame()
        {
            allGuessings.Add(SequenceNumber[index]);
            return SequenceNumber[index++];
        }      

    }
}
