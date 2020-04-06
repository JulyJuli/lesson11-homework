using System;
using System.Collections.Generic;

namespace HW3003.Players
{
    public abstract class Player
    {           
        public List<int> SequenceNumber = SequenceNumbers();

        public List<int> SequenceRandomNumber = SequenceRandomNumbers(SequenceNumbers());

        public static List<int> SequenceNumbers()
        {
            int startNumber = 40;
            int countNumber = 100;
            countNumber += 1;
            List<int> numbersIn = new List<int>();
            
            for (int i = 0; i < countNumber; i++)
            {
                int number = startNumber + i;
                numbersIn.Add(number);
            }
            return numbersIn;
        }

        public static List<int> SequenceRandomNumbers(List<int> numbers)
        {
            Random rnd = new Random();
            for (int i = 0; i < numbers.Count; i++)
            {
                int ran = rnd.Next(0, 100);
                numbers[ran] = numbers[i];
            }
            return numbers;
        }

        protected static readonly List<int> allGuessings = new List<int>();
        public static List<int> Test = allGuessings;        

        protected abstract string PlayerType { get; }

        public string PlayerName()
        {
            return PlayerType;
        }
        public abstract int GuessingGame();       

        public void PrintCurrentResult(int guessedNumber)
        {
            
            Console.WriteLine($"{PlayerType} geussed {guessedNumber}");            
        }
        public override string ToString ()
        {           
            return $"{PlayerType} won the game";            
        }
    }
}
