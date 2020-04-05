using System;
using System.Collections.Generic;


namespace GameWithBasket
{
    class Program
    {
        public static void Main(string[] args)
        {
            var weightOfBasket = new Random().Next(40, 100);
            var countOfAttemts = 100;
            List<Player> players = new List<Player>()
            {
                new GeneralPlayer (),
                new NotePlayer(),
                new UberPlayer(),
                new UberCheater (),
                new Cheater ()
            };

            var currentGame = new CurrentGame();
            currentGame.NearestValue = 0;

            for (int i = 0; i < countOfAttemts - players.Count - 1; i += players.Count - 1)
            {
                int choice = 0;
                foreach (var player in players)
                {
                    choice = player.GetValue(currentGame.allTrials);
                    currentGame.allTrials.Add(choice);
                    Console.WriteLine($"Player {player.TypeName} selected {choice}");
                    if (Math.Abs(weightOfBasket - choice) < Math.Abs(weightOfBasket - currentGame.NearestValue))
                    {
                        currentGame.NearestValue = choice;
                        currentGame.PotentialWinner = player.TypeName;
                    }
                    if (weightOfBasket == choice)
                    {
                        Console.WriteLine(player.ToString());
                        break;
                    }
                }
                if (weightOfBasket == choice)
                {
                    break;
                }
                    Console.WriteLine("-------------------------");
            }

            Console.ReadKey();

        }
    }
}
