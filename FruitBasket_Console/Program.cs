using System;
using System.Collections.Generic;
using FruitBasket_DLL;

namespace FruitBasket_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var randomSeed = new Random();
            var basket = new Basket(randomSeed);

            Console.WriteLine($"Basket's weight is {basket.Weight} kg.");

            //
            //Creating players:

            Console.Write("Enter the number of players (from 2 to 8): ");

            string input = Console.ReadLine();
            int minPlayers = 2;
            int maxPlayers = 8;

            int numOfPlayers = InputValidation(input, minPlayers, maxPlayers);

            var playersList = new List<Player>();

            for (int i = 1; i <= numOfPlayers; i++)
            {
                Console.WriteLine($"Select the type of {i} player");
                Console.WriteLine("1 - Regular Player");
                Console.WriteLine("2 - Notebook Player");
                Console.WriteLine("3 - Uber-Player");
                Console.WriteLine("4 - Cheater");
                Console.WriteLine("5 - Uber-Cheater Player"); 

                int type = InputValidation(Console.ReadLine(), 1, 5);

                switch (type)
                {
                    case 1:
                        playersList.AddPlayerToList(new RegularPlayer(randomSeed));

                        break;
                    case 2:
                        playersList.AddPlayerToList(new NotebookPlayer(randomSeed));

                        break;
                    case 3:
                        playersList.AddPlayerToList(new UberPlayer());

                        break;
                    case 4:
                        playersList.AddPlayerToList(new CheaterPlayer(randomSeed));

                        break;
                    case 5:
                        playersList.AddPlayerToList(new UberCheaterPlayer());

                        break;
                }
            }

            var totalTriesList = new List<List<int>>();

            foreach (var player in playersList)
            {
                totalTriesList.Add(player.PersonalTries);
            }

            //
            //Let the game begin!

            for (int tries = 1; tries <= 100; tries++)
            {
                Console.WriteLine($"Try #{tries}");

                foreach (var player in playersList)
                {
                    int newTry = player.Guess(Basket.MinWeight, Basket.MaxWeight, ref totalTriesList);

                    Console.WriteLine($"{player.TypeName} {player.Name} says {newTry}");

                    if (newTry == basket.Weight)
                    {
                        Console.WriteLine($"{player.TypeName} {player.Name} wins!");
                        Console.ReadKey();
                        return;
                    }
                }

                Console.WriteLine();
            }

            //
            //If nobody guessed correctly:

            var bestTriesList = new List<int>();

            foreach (Player player in playersList)
            {
                player.BestTry = player.PersonalTries.GetBestTry(basket.Weight);
                Console.WriteLine($"{player.TypeName} {player.Name}'s closest guess is {player.BestTry}");

                bestTriesList.Add(player.BestTry);
            }

            int totalBestTry = bestTriesList.GetBestTry(basket.Weight);

            foreach(Player player in playersList)
            {
                if (player.BestTry == totalBestTry)
                {
                    Console.WriteLine($"{player.TypeName} {player.Name} wins! Their closest guess is {player.BestTry}");
                }
            }

            Console.ReadKey();
        }

        public static int InputValidation(string input, int minValue, int maxValue)
        {
            int result;
            while (int.TryParse(input, out result) == false || minValue > result || maxValue < result)
            {
                Console.Write("Please try again: ");
                input = Console.ReadLine();
            }

            return result;
        }
    }
}
