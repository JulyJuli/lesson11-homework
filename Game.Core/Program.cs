using Game.Game;
using Game.PlayersGame;
using System;
using System.Collections.Generic;
using System.IO;

namespace Program
{
    public class Program
    {
        List<Players> TestDataset()
        {
            const int playersCount = 2;
            var players = new List<Players>();

            for (int i = 0; i < playersCount; i++)
            {
                var random = new PlayerNotepad($"PlayerNotepad-{i}");
                players.Add(random);
            }

            var cheater = new CheaterPlayer("CheaterPlayer");
            players.Add(cheater);

            var uberCheater = new UberCheaterPlayer("UberCheaterPlayer");
            players.Add(uberCheater);

            return players;
        }
        private void BreakOutput()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
        }
        public virtual void Log(Guid gameId, string message, bool syncVersion = true)
        {
            if (syncVersion)
            {
                FileStream fs = new FileStream($@"Games\Game-{gameId.ToString()}.txt", FileMode.Append);

                TextWriter consoleOutput = Console.Out;

                StreamWriter fileOutput = new StreamWriter(fs);

                Console.SetOut(fileOutput);
                Console.WriteLine(message);

                Console.SetOut(consoleOutput);
                Console.WriteLine(message);

                fileOutput.Close();
            }
            else
            {
                Console.WriteLine(message);
            }
        }
        private void PlayGame(Program main)
        {
            const string yes = "yes";

            Console.WriteLine("Sync game? y/n?");

            bool sync = Console.ReadLine() == yes;

            var players = main.TestDataset();

            var game = new GameClass(players);

            var result = game.Start(sync);

            main.Log(game.GameId, "Game is over ", sync);
            main.Log(game.GameId, "Attempts: " + game.Attempts, sync);
            main.Log(game.GameId, "RealWeight: " + result.RealWeight, sync);
            main.Log(game.GameId, "Won: " + result.WonPlayerName, sync);

            if (string.IsNullOrEmpty(result.WonPlayerName))
            {
                main.Log(game.GameId, "Nearest Name: " + result.Nearest.Name, sync);
                main.Log(game.GameId, "Nearest Guess: " + result.Nearest.Guess, sync);
            }

            Console.WriteLine("Restart game, y/n");

            if (Console.ReadLine() == yes)
            {
                main.BreakOutput();

                main.PlayGame(main);
            }
        }

        static void Main(string[] args)
        {
            CheckGamesFolderExistence();

            var main = new Program();

            main.PlayGame(main);
        }

        static void CheckGamesFolderExistence()
        {
            if (!Directory.Exists(@"Games"))
            {
                Directory.CreateDirectory(@"Games");
            }
        }
    }
}