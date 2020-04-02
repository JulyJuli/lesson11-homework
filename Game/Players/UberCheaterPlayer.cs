using System.Collections.Generic;

namespace Game.Players
{
    public class UberCheaterPlayer : BasePlayer
    {

        private int currentCount = MinBoudary;

        public UberCheaterPlayer(string playerType) : base(playerType)
        { }

        protected override string PlayerType { get; set; }
        public override int GuessNumber(List<int> guess)
        {
     
            var counter = 1;
            while (allGuessings.Contains(currentCount))
            {
                if (counter < 6)
                {
                    counter++;
                    currentCount++;
                }
            }
            return currentCount;
        }
    }
}
