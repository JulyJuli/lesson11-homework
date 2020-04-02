using System;
using System.Collections.Generic;

namespace Poslednjaja_popytka
{
    public class Program
    {
        public static List<ProcessGuessing> allPlayersAndGuessings = new List<ProcessGuessing>();

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


            bool notGuess = true;

            for (int i = 0; i < numberOfAttempts - playerList.Count - 1 && notGuess; i += playerList.Count)
            {
                for (int j = 0; j < playerList.Count; j++)
                {
                    playerList[j].Guess = playerList[j].GuessNumber();
                    var currentPlayer = new ProcessGuessing(playerList[j], playerList[j].Guess);
                    allPlayersAndGuessings.Add(currentPlayer);
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


            Console.WriteLine($"The winner: {SearchWinner()}");


            Console.ReadKey();
        }
        public static string SearchWinner()
        {
            ProcessGuessing searchWinner = allPlayersAndGuessings[0];

            int min = Math.Abs(FruitBasket.Weight - allPlayersAndGuessings[0].Weight);

            for (int i = 0; i < allPlayersAndGuessings.Count; i++)
            {
                if (min > Math.Abs(FruitBasket.Weight - allPlayersAndGuessings[i].Weight))
                {
                    min = Math.Abs(FruitBasket.Weight - allPlayersAndGuessings[i].Weight);
                    searchWinner = allPlayersAndGuessings[i];
                }
            }

            return $"The winner is: {searchWinner}";
        }
    }
}
