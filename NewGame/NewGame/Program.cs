using NewGame.Players;
using System;
using System.Collections.Generic;

namespace NewGame
{
    class Program
    {
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
            int helpNumber = 0;

            for (int i = 0; i < numberOfAttempts - playerList.Count - 1 && notGuess; i += playerList.Count)
            {
                for (int j = 0; j < playerList.Count; j++)
                {
                    playerList[j].Guess = playerList[j].GuessNumber(helpNumber);

                    var currentPlayer = new ProcessGuessing(playerList[j], playerList[j].Guess);
                    ProcessGuessing.allPlayersAndGuessings.Add(currentPlayer);

                    bool win = playerList[j].CheckGuessedNumbers(playerList[j].Guess);
                    playerList[j].PrintInfo(playerList[j].Guess);


                    if (win == true)
                    {
                        playerList[j].WinMessage();
                        notGuess = false;
                        break;
                    }

                }
                Console.WriteLine("======================================");
            }

            Console.WriteLine(SearchWinner());

            Console.ReadKey();
        }
        public static string SearchWinner()
        {
            ProcessGuessing searchWinner = ProcessGuessing.allPlayersAndGuessings[0];

            int min = Math.Abs(FruitBasket.Weight - ProcessGuessing.allPlayersAndGuessings[0].Weight);

            for (int i = 0; i < ProcessGuessing.allPlayersAndGuessings.Count; i++)
            {
                if (min > Math.Abs(FruitBasket.Weight - ProcessGuessing.allPlayersAndGuessings[i].Weight))
                {
                    min = Math.Abs(FruitBasket.Weight - ProcessGuessing.allPlayersAndGuessings[i].Weight);
                    searchWinner = ProcessGuessing.allPlayersAndGuessings[i];
                }
            }
            return $"The winner is: {searchWinner}";
        }
    }
}

