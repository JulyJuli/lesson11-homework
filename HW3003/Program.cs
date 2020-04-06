using HW3003.Players;
using System;
using System.Collections.Generic;

namespace HW3003
{
    class Program
    {
        static void Main(string[] args)
        {            
            var numberOfAttempts = 102;
            var basketWeight = new Random().Next(40, 140);
            Console.WriteLine($"\nBasket weight: {basketWeight}\n");


            var playersList = new List<Player>()
            {
                new UberPlayer(),
                new NotePlayer(),
                new UsualPlayer(),
                new UberCheaterPlayer(),
                new CheaterPlayer()
            };
            bool check = true;
            int count = 1;
            List<SearchWinnerPlayers> players = new List<SearchWinnerPlayers>();
            for (int i = 0; i < numberOfAttempts - playersList.Count - 1 && check; i += playersList.Count)
            {
                Console.WriteLine($"\n----------- Attempts № {count++} -----------\n");
                for (int j = 0; j < playersList.Count && check; j++)
                {
                    var guessedNumber = playersList[j].GuessingGame();
                    playersList[j].PrintCurrentResult(guessedNumber);

                    var allPlayer = new SearchWinnerPlayers(playersList[j].PlayerName(), guessedNumber);
                    players.Add(allPlayer);

                    if (guessedNumber == basketWeight)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.WriteLine(playersList[j].ToString());
                        Console.ResetColor();
                        check = false;
                    }
                }
            }        


            if (check == true)
            {
                SearchWinnerPlayers.SearchNumber(players, basketWeight);
            }
            Console.ReadKey();
        }
    }
}
