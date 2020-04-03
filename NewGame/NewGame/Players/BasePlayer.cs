using System;
using System.Collections.Generic;

namespace NewGame.Players
{
    public abstract class BasePlayer
    {

        protected const int MinBoundary = 40;
        protected const int MaxBoundary = 140;
        public static int attempt = 1;

        public bool isGuessed;

        protected static readonly List<int> allGuessedNumbers = new List<int>();
        public BasePlayer()
        {
        }

        public int Guess { get; set; }
        public TypeOfPlayer TypeOfPlayer { get; set; }

        public abstract int GuessNumber(int i);
      

        public void PrintInfo(int currentGuess)
        {
            Console.WriteLine($"{attempt++} - {TypeOfPlayer} guess it's number {currentGuess}");
        }

        public void WinMessage()
        {
            Console.WriteLine($"{TypeOfPlayer} win - {Guess}");
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


