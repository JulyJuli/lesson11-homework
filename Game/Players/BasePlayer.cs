using System;
using System.Collections.Generic;

namespace Game
{
    public abstract class BasePlayer
    {
        
        protected const int MinBoudary = 40;
        protected const int MaxBoudary = 140;
        protected readonly List<int> allGuessings;
        public BasePlayer(string playerType)
        {
            allGuessings = new List<int>();
            PlayerType = playerType;
        }
        protected abstract string PlayerType { get; set; }

        public virtual int GuessNumber(List<int> guess)
        {
            return 0;
        }

        public void PrintCurrentResult(int guessedNumber)
        {
            Console.WriteLine($"{PlayerType} guessed {guessedNumber}");
        }
        public virtual string InfoPlayer()
        {

            return $"Closer the weight basket: {PlayerType}";
        }
        public override string ToString()
        {
            
            return $"Guessed the weight basket: {PlayerType}";
        }

    }
}
