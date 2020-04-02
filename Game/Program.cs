using System;
using System.Collections.Generic;
using Game.Players;

namespace Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numberOfAttempts = 100;
            var basketWeight = new Random().Next(40, 140);
            var guess = new List<int>();
            var playersList = new List<BasePlayer>()
            {
                new NotepadPlayer("Maksym"),
                new UsualPlayer("Valeriia"),
                new UberPlayer("Araz"),
                new CheaterPlayer("Anton"),
                new UberCheaterPlayer("Kolya")
            };

            Console.WriteLine($"Basket weight: {basketWeight}");

            for (int i = 0; i < numberOfAttempts - playersList.Count - 1; i += playersList.Count)
            {
                foreach (var player in playersList)
                {
                    var guessedNumber = player.GuessNumber(guess);
                    player.PrintCurrentResult(guessedNumber);
                    if (guessedNumber == basketWeight)
                    {
                        Console.WriteLine(player.ToString());
                        Console.ReadLine();
                        break;

                    }
                }

                Console.WriteLine("-----------------------------");
            }

            for (int i = 0; i < numberOfAttempts - playersList.Count - 1; i += playersList.Count)
            {
                foreach (var player in playersList)
                {
                    var guessedNumber = player.GuessNumber(guess);
                    var newGuessed = basketWeight + 1;
                    var newGuessedfrst = basketWeight - 1;
                    if (newGuessed == guessedNumber ||newGuessedfrst==guessedNumber)
                    {
                        Console.WriteLine(player.InfoPlayer());
                        Console.ReadLine();
                        break;

                    }
                }

                Console.WriteLine("-----------------------------");
            }
            Console.WriteLine("NO ONE GUESSED THE WEIGHT BASKET");
            Console.ReadLine();
        }
    }
}
