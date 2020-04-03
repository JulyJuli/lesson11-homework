using System;
using System.Collections.Generic;
using Game.enums;
using Game.interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Game.classes
{
    public class InitGame
    {
        private const int MIN_PLAYERS = 2;
        private const int MAX_PLAYERS = 8;
        private const int MAX_ATTEMPTS = 100;
        private const int MIN_VALUE = 40;
        private const int MAX_VALUE = 140;
        
        public InitGame()
        {
            Start();
        }

        private void Start()
        {
            Console.Clear();
            var secretValue = new Random().Next(MIN_VALUE, MAX_VALUE);
            var players = new List<IHuman>();
            var attempts = new List<int>();
            var linkPlayer = 0;
            var guessed = false;
            
            GeneratePlayers(players);
            
            var difference = MAX_VALUE - MIN_VALUE;
            var closestNumber = 0;
            var closestPlayer = players[linkPlayer];
            
            Console.WriteLine("Real basket weight = {0}\n", secretValue);
            Console.WriteLine("Players:\n");

            foreach (var player in players)
            {
                Console.WriteLine(player.ToString());
            }
            
            Console.Write("\nAttempts:\n");

            while (attempts.Count < MAX_ATTEMPTS && !guessed)
            {
                var attempt = players[linkPlayer].GetNumber(attempts);
                
                if (attempt == secretValue)
                {
                    guessed = true;
                    closestPlayer = players[linkPlayer];
                }

                if (!guessed && difference > Math.Abs(attempt - secretValue))
                {
                    difference = Math.Abs(attempt - secretValue);
                    closestNumber = attempt;
                    closestPlayer = players[linkPlayer];
                }
                Console.WriteLine($"player: {players[linkPlayer].Name, -25}; attempt = {attempt}");
                linkPlayer++;
                if (linkPlayer > players.Count - 1)
                {
                    linkPlayer = 0;
                }
                
                attempts.Add(attempt);
            }

            Console.WriteLine(guessed
                ? $"\nPlayer \"{closestPlayer.Name}\" guessed the weight of the basket({secretValue})!\n"
                : $"\nNo one guessed the weight of the basket({secretValue}). The closest was \"{closestPlayer.Name}\" with a basket weight of {closestNumber}!\n");

            Console.WriteLine("Wont more? (y/n)");
            
            var key = Console.ReadKey(true).KeyChar;

            switch (key)
            {
                case 'y':
                    Start();
                    break;

                case 'n':
                    break;

                default:
                    Start();
                    break;
            }
        }
        
        private void GeneratePlayers(List<IHuman> players)
        {
            var services = new ServiceCollection();
           
            Startup startup = new Startup();
            startup.ConfigureServices(services);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var shuffleService = serviceProvider.GetService<IAbleToShuffle>();
            
            /*var PlayerTypeDict = new Dictionary<PlayerType, IHuman>
            {
                {PlayerType.Regular, new Regular("Regular")},
                {PlayerType.Notepad, new Notepad("Notepad", shuffleService)},
                {PlayerType.Uber, new Uber("Uber")},
                {PlayerType.Cheater, new Cheater("Cheater", shuffleService)},
                {PlayerType.UberCheater, new UberCheater("UberCheater")}
            };*/
            
            var playerCount = new Random().Next(MIN_PLAYERS, MAX_PLAYERS);

            for (int i = 0; i < playerCount; i++)
            {
                IHuman player;
                var playerTypeValues = Enum.GetValues(typeof(PlayerType));
                PlayerType randomPlayerType = (PlayerType)playerTypeValues.GetValue(new Random().Next(playerTypeValues.Length));
                
                switch (randomPlayerType)
                {
                    case PlayerType.Regular:
                        player = new Regular($"Regular Player {i}");
                        break;

                    case PlayerType.Notepad:
                        player = new Notepad($"Notepad Player {i}", shuffleService);
                        break;

                    case PlayerType.Uber:
                        player = new Uber($"Uber Player {i}");
                        break;
                
                    case PlayerType.Cheater:
                        player = new Cheater($"Cheater Player {i}", shuffleService);
                        break;
                    
                    case PlayerType.UberCheater:
                        player = new UberCheater($"Uber Cheater Player {i}");
                        break;

                    default:
                        player = new Regular($"Regular Player {i}");
                        break;
                }
                
                players.Add(player);
            }
        }
    }
}