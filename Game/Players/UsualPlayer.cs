using System;
using System.Collections.Generic;

namespace Game.Players
{
    public class UsualPlayer : BasePlayer
    {
        public UsualPlayer(string playerType) : base(playerType)
        { }

        protected override string PlayerType { get; set; }
        public override int GuessNumber(List<int> guess)
        {

            var guessedNumber= new Random().Next(maxValue: MaxBoudary, minValue: MinBoudary);
            return guessedNumber;
        }
    }
}
