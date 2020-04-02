using System.Collections.Generic;

namespace Game.Players
{
    public class UberPlayer : BasePlayer
    {
        private int currentGuess = MinBoudary;
        public UberPlayer(string playerType) : base(playerType)
        { }

        protected override string PlayerType { get; set; }
        public override int GuessNumber(List<int> guess)
        {
             return currentGuess++;
        }
    }
}
