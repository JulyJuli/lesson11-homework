using System;
using System.Collections.Generic;

namespace Game.Players
{
    public class NotepadPlayer : BasePlayer
    {
        private readonly List<int> passedGuessing; 
        public NotepadPlayer(string playerType): base(playerType)
        {
            passedGuessing = new List<int>();
        }
        protected override string PlayerType { get; set; }
        

        public override int GuessNumber(List<int> guess)
        {
            var randNumber= new Random().Next(maxValue: MaxBoudary, minValue: MinBoudary);
            int counter = 1;
            while(passedGuessing.Contains(randNumber))
            {
                if (counter < 6)
                {
                    counter++;
                    randNumber = new Random().Next(maxValue: MaxBoudary, minValue: MinBoudary);
                }
            }
            return randNumber;
        }
    }
}
