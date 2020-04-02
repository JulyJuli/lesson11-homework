using System;
using System.Collections.Generic;

namespace Game.Players
{
    public class CheaterPlayer : BasePlayer
    {
        public CheaterPlayer(string playerType) : base(playerType)
        {}

        protected override string PlayerType { get; set; }
        public override int GuessNumber(List<int> guess)
        {
            var randNumber = new Random().Next(maxValue: MaxBoudary, minValue: MinBoudary);
            var counter = 1;
            while(allGuessings.Contains(randNumber))
            {
                if (counter<6)
                {
                    counter++;
                    randNumber = new Random().Next(maxValue: MaxBoudary, minValue: MinBoudary);

                }
            }
            allGuessings.Add(randNumber);
            return randNumber;
        }
    }
}
