using HW3003.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3003
{
    public class UsualPlayer : Player
    {       
        protected override string PlayerType => "Usual Player";
        int index = 0;
        public override int GuessingGame()
        {            
            var guessedNumber = SequenceRandomNumber[index++];
            allGuessings.Add(guessedNumber);
            return guessedNumber;

        }   
    }
}
