using System;
using System.Collections.Generic;

namespace HomeWork11GameLibrary
{

    public abstract class Player
    {
        public static int MinWeight = 40;
        public static int MaxWeight = 140;
        public static int MaxAttempts = 100;

        //public static List<Player> AllPlayers = new List<Player>();

        public static bool isGuessed = false;
        public static int Attempts { get; set; }

        public static List<List<int>> AllListsNumbers = new List<List<int>>();

       // public static List<Player> Players { get; set; }

        public Player(string name, TypeOfPlayer typeOfPlayer)
        {
            Name = name;
            TypeOfPlayer = typeOfPlayer;
        }

        public TypeOfPlayer TypeOfPlayer { get; }
        public int Weight { get; set; }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = InputValidation(value);
            }
        }

        private string InputValidation(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
            return $"Incorrect! Try a gain.";
        }

        public int Guessed { get; set; }

        public virtual int Guessing()
        {
            return Guessed = new Random().Next(MinWeight, MaxWeight);
        }

        public static List<int> AddGuessNumbers(List<int> numbers, int guesseingNumber)
        {
            numbers.Add(guesseingNumber);
            return numbers;
        }

        public override string ToString()
        {
            return $"{Attempts + 1}. I am {TypeOfPlayer}-player, my name is {Name} and I guess it's number {Guessed}!";
        }

        public void PrintMassege()
        {
            Console.WriteLine(ToString());
        }

        public List<int> AddValues(List<int> fillinglList)
        {
            for (int i = MinWeight; i < MaxWeight; i++)
            {
                fillinglList.Add(i);
            }
            return fillinglList;
        }

        public bool CheckGuessedNumbers(int guessingNumber)
        {
            if (FruitBasket.Weight == guessingNumber)
            {
                return isGuessed = true;
            }
            return isGuessed = false;
        }

        public List<List<int>> JaggedList(List<int> playerList)
        {
            AllListsNumbers.Add(playerList);

            return AllListsNumbers;
        }
    }
}

