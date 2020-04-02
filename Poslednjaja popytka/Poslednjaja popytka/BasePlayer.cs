using System;
using System.Collections.Generic;

namespace Poslednjaja_popytka
{
    public abstract class BasePlayer
    {

        protected const int MinBoundary = 40;
        protected const int MaxBoundary = 140;

        public bool isGuessed;

        protected static readonly List<int> allGuessedNumbers = new List<int>();
        public BasePlayer()
        {
        }

        public int Guess { get; set; }
        protected TypeOfPlayer TypeOfPlayer { get; set; }

        public abstract int GuessNumber();

        public void PrintInfo(int currentGuess)
        {
            Console.WriteLine($"{TypeOfPlayer} guess it's number {currentGuess}");
        }

        public override string ToString()
        {
            return $"{TypeOfPlayer} win - {Guess}";
        }

        public bool CheckGuessedNumbers(int guessingNumber)
        {
            if (FruitBasket.Weight == guessingNumber)
            {
                return isGuessed = true;
            }
            return isGuessed = false;
        }
    }
}
