using System;
using System.Collections.Generic;
using Game.Players;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfAttempts = 100;
            var basketWeight = new Random().Next(40, 140);
            Console.WriteLine($"Weight of basket {basketWeight}\n______________________");
            var playersList = new List<BasePlayer>()
            {
                new OrdynaryPlayer(),
                new PlayerNotepad(),
                new UberPlayer(),
                new UberCheater(),
                new CheaterPlayer()
            };
            for(int i=0; i < numberOfAttempts-playersList.Count-1; i += playersList.Count)
            {
                foreach (var player in playersList)
                {
                    var guessedNumber = player.GuessesNumber();
                    player.PrintResult(guessedNumber);
                    if (guessedNumber == basketWeight)
                    {
                        Console.WriteLine(player.ToString());
                    }   
                }
                Console.WriteLine("-----------------------");
                
            }
            
            Console.ReadKey();
        }
    }
}
