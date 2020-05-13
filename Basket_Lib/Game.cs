using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using static Basket_Lib.DelegateHolder;

namespace Basket_Lib
{

    public class Game
    {
        public static readonly object locker = new object();
        public List<Attempt> AttemptList { get; private set; }
        public List<Player> PlayerList { get; private set; }
        public int MaxBasketWeight { get; private set; }
        public int MinBasketWeight { get; private set; }
        private ShowMessage MessageHandler { get; set; }
        public int GuessedNumber { get; private set; }


        private static CancellationTokenSource CTS = new CancellationTokenSource();
        private static CancellationToken Token = CTS.Token;
        private Task[] Tasks { get; set; }  // Because I want to.




        public Game(int min = 40, int max = 140, int guessedNumber = 141, int maxAttempts = 100)
        {
            MinBasketWeight = min;
            MaxBasketWeight = max;
            GuessedNumber = guessedNumber;
            AttemptList = new List<Attempt>(maxAttempts);
            PlayerList = new List<Player>();

        }

        public void SetMessageHandler(ShowMessage message)
        {
            MessageHandler = message;
        }

        public void Go()
        {
            // Creating task collection.
            Tasks = new Task[PlayerList.Count];
            for (int i = 0; i < PlayerList.Count; i++)
            {
                Tasks[0] = new Task(() => PlayerList[0].GetGuess(this), Token);

            }
            foreach (var player in PlayerList)
            {
                Task.Run(() => player.GetGuess(this));
            }

            // Displaying game info (as a banner) in console.
            MessageHandler($"Guessed number is: {GuessedNumber}.");
            MessageHandler($"Basket borders: {MinBasketWeight }...{MaxBasketWeight}.\n");

            // They are alive!!!! =)
            foreach (var task in Tasks)
            {
                task?.RunSynchronously();
            }
        }

        private void GameFinishing()
        {
            MessageHandler($"    No winners...\n");
            int closestAttempt = AttemptList.OrderBy(i => Math.Abs(i.ChosedNumber - GuessedNumber)).ToList()[0].ChosedNumber;
            List<Attempt> almostWinnerList = AttemptList.OrderBy(i => Math.Abs(i.ChosedNumber - GuessedNumber)).TakeWhile(i => i.ChosedNumber == closestAttempt).ToList();

            if (almostWinnerList.Count == 1) { MessageHandler(" The closest attempt is:"); }
            else { MessageHandler(" The closest attempts was:"); }

            foreach (var attempt in almostWinnerList)
            {
                MessageHandler($"  {attempt.PlayerName}, {attempt.PlayerType}, ID {attempt.PlayerID}" +
                        $" - chosed number: {attempt.ChosedNumber}. ");
            }
        }


        public void AddPlayer(Player player)
        {
            PlayerList.Add(player);
        }

        public void AttemptProcessing(Attempt attempt)
        {
            lock (locker)
            {
                // When attempts count reaches attempt capacity - game is finished,
                // tasks need to be disposed.
                if (AvailableAttemptsCheck() == false)
                {
                    GameFinishing(); // Printing info of almost winners' attempts.
                    TasksDispose();
                    return;
                }
                AttemptList.Add(attempt);
                if (attempt.ChosedNumber == GuessedNumber)
                {
                    DisplayWinner();

                    // I think it can be a little more winners if 
                    //i will not do .Dispose() for all tasks.
                    TasksDispose();
                }
            }
        }

        public void DisplayWinner()
        {
            MessageHandler($"The winner is {GetWinner().PlayerName} (id \"{GetWinner().PlayerID}\")," +
                        $" {GetWinner().PlayerType.ToLower()}, with number {GetWinner().ChosedNumber}!!! ");
        }

        private Attempt GetWinner()
        {
            return AttemptList.Last();
        }

        public bool AvailableAttemptsCheck()
        {
            return (AttemptList.Count <= AttemptList.Capacity) ? true : false;
        }

        public void TasksDispose()
        {
            foreach (Task task in Tasks)
            {

                task.Dispose();
            }
        }
    }
}
