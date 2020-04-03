using System;
using System.Collections.Generic;

namespace Poslednjaja_popytka
{
    public class Program
    {
        // public static List<ProcessGuessing> allPlayers = new List<ProcessGuessing>();
        public static void Main(string[] args)
        {
            var numberOfAttempts = 100;
            var fruitBasket = new FruitBasket();
            fruitBasket.PrintInfo();


            var playerList = new List<BasePlayer>()
            {
                new UsualPlayer(),
                new NotepadPlayer(),
                new UberPlayer(),
                new CheaterPlayer(),
                new UberCheaterPlayer()
            };

            var allPlayersList = new List<ProcessGuessing>();

            bool notGuess = true;

            for (int i = 0; i < numberOfAttempts - playerList.Count - 1 && notGuess; i += playerList.Count)
            {
                for (int j = 0; j < playerList.Count; j++)
                {
                    playerList[j].Guess = playerList[j].GuessNumber();
                    var currentPlayer = new ProcessGuessing(playerList[j], playerList[j].Guess);

                    allPlayersList.Add(currentPlayer);

                    bool win = playerList[j].CheckGuessedNumbers(playerList[j].Guess);
                    playerList[j].PrintInfo(playerList[j].Guess);

                    if (win == true)
                    {
                        Console.WriteLine(playerList[j].ToString(), playerList[j].Guess);
                        notGuess = false;
                        break;
                    }

                }
                Console.WriteLine("======================================");
            }


            // Console.WriteLine($"The winner: {SearchWinner(allPlayersList)}");


            Console.WriteLine($"The winner: {SearchWinner()}");

            Console.ReadKey();
        }
        public static int SearchWinner()
        {
            int result = 0;
            int min = BasePlayer.allGuessedNumbers[0];

            for (int i = 0; i < BasePlayer.allGuessedNumbers.Count; i++)
            {
                if (min > Math.Abs(FruitBasket.Weight - BasePlayer.allGuessedNumbers[i]))
                {
                    min = Math.Abs(FruitBasket.Weight - BasePlayer.allGuessedNumbers[i]);
                    result = BasePlayer.allGuessedNumbers[i];
                }
            }
            return result;

            //ProcessGuessing searchWinner = allPlayersList[0];

            //int min = Math.Abs(FruitBasket.Weight - allPlayersList[0].Weight);

            //for (int i = 0; i < allPlayersList.Count; i++)
            //{
            //    if (min > Math.Abs(FruitBasket.Weight - allPlayersList[i].Weight))
            //    {
            //        min = Math.Abs(FruitBasket.Weight - allPlayersList[i].Weight);
            //        searchWinner = allPlayersList[i];
            //    }
            //}

            //return $"The winner is: {searchWinner}";
        }
    }
}
