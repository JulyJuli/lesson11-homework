using HW3003.Players;
using System.Collections.Generic;

namespace HW3003
{
    public class NotePlayer : Player
    {        
        private readonly List<int> passedGuessings;
        public NotePlayer()
        {
            passedGuessings = new List<int>();
        }
        protected override string PlayerType => "Note Player";

        int index = 0;
        public override int GuessingGame()
        {
            var randNumber =  SequenceRandomNumber[index++];
            var counter = 1;

            while (passedGuessings.Contains(randNumber))
            {
                if (counter < 6)
                {
                     counter++;
                     randNumber = SequenceRandomNumber[index++];
                }               
            }
            passedGuessings.Add(randNumber);
            allGuessings.Add(randNumber);
            
            return randNumber;
        }      

    }
}
