using Game.PlayersGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Game
{
    public class GameClass
    {
        private static int GameTime = 1000;
        Random rand = new Random();

        private static bool isGuessed;
        private static bool isGameEnded;

        private bool syncFlag = false;

        List<Task> tasks = new List<Task>();
        public void Log(Guid gameId, string message, bool syncVersion = true) { }

        public GameClass(List<PlayersGame.Players> players)
        {
            isGuessed = false;
            isGameEnded = false;

            this.GameId = Guid.NewGuid();

            Log(this.GameId, $"Game id:  {this.GameId.ToString()}");
            Weight = PlayersGame.Players.PrintGuess();
            Log(this.GameId, $"  weight : {Weight}");
            GuessedNumbers = new List<int>();
            TimeForGame = GameTime;


            foreach (var player in Players)
            {
                tasks.Add(new Task(() => DoPlayerStuff(player)));
            }
        }

        private static DateTime GameStarted { get; set; }

        private static int TimeForGame { get; set; }

        public int Weight { get; set; }

        public Guid GameId { get; set; }

        public List<PlayersGame.Players> Players { get; set; }

        public volatile int Attempts;

        public Players Won { get; set; }

        public static bool _isTimeEnded;

        private static bool Exit()
        {
            _isTimeEnded = (DateTime.Now > GameStarted.AddMilliseconds(TimeForGame));

            if (_isTimeEnded)
            {
                Console.WriteLine("Time is up");
            }

            return (isGuessed || isGameEnded || _isTimeEnded);
        }

        public static List<int> GuessedNumbers { get; set; }

        public bool IsGuessed(int number, Players player)
        {
            const int attemptsCount = 100;

            GuessedNumbers.Add(number);

            isGuessed = Weight == number;
            Attempts++;

            isGameEnded = Attempts == attemptsCount;

            if (isGuessed)
            {
                if (!isGameEnded)
                {
                    Won = player;
                }
            }
            else
            {
                var timeToWait = WaitTime(number);
                player.AddWaitTime(timeToWait);

                Log(this.GameId, $"player {player.Name}  waits : {player.WaitingTime}", this.syncFlag);
            }

            return isGuessed;
        }

        public int WaitTime(int number)
        {
            return Math.Abs(Weight - number);
        }

        private void DoPlayerStuff(Players player)
        {
            if (Exit())
            {
                return;
            }

            while (!Exit())
            {
                var num = player.Guess();

                Log(this.GameId, $"player {player.Name} tries: " + num, this.syncFlag);
                IsGuessed(num, player);
            }
        }

        public Result Start(bool sync)
        {
            GameStarted = DateTime.Now;

            this.syncFlag = sync;

            if (sync)
            {
                while (!Exit())
                {
                    foreach (var player in Players)
                    {
                        DoPlayerStuff(player);
                    }
                }
            }
            else
            {
                foreach (var task in this.tasks)
                {
                    task.Start();
                }

                Task.WaitAll(this.tasks.ToArray());
            }

            return GetResult();
        }

        private Result GetResult()
        {
            var result = new Result();
            result.RealWeight = Weight;

            if (Won != null)
            {
                result.WonPlayerName = Won.Name;
            }

            var allNearestNumbers = new List<PlayerGuess>();

            foreach (var item in Players)
            {
                if (!item.Answers.Any())
                {
                    continue;
                }

                int closestGuess
                    = item.Answers.Aggregate((x, y) =>
                            Math.Abs(x - Weight) < Math.Abs(y - Weight) ? x : y);

                var playerGuess = new PlayerGuess();
                playerGuess.Guess = closestGuess;
                playerGuess.Name = item.Name;

                allNearestNumbers.Add(playerGuess);
            }

            if (allNearestNumbers.Any())
            {
                var closest
                    = allNearestNumbers.Aggregate((x, y) =>
                        Math.Abs(x.Guess - Weight) < Math.Abs(y.Guess - Weight) ? x : y);

                result.Nearest = closest;
            }

            return result;
        }
    }
}