using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Basket_Lib
{
    public class Game
    {
        public static readonly object locker = new object();
        public List<Attempt> AttemptList { get; private set; }
        public List<Player> PlayerList { get; private set; }
        public int MaxBasketWeight { get; private set; }
        public int MinBasketWeight { get; private set; }
        public int MaxAttempts { get; set; }
        private Action<string> MessageHandler { get; set; }
        public int GuessedNumber { get; private set; }


        private static CancellationTokenSource CTS = new CancellationTokenSource();
        public static CancellationToken token = CTS.Token;
        private Task[] Tasks { get; set; }  // Because I want to.


        public Game(int min = 40, int max = 140, int guessedNumber = 141, int maxAttempts = 100)
        {
            MinBasketWeight = min;
            MaxBasketWeight = max;
            GuessedNumber = guessedNumber;
            AttemptList = new List<Attempt>();
            PlayerList = new List<Player>();
            MaxAttempts = maxAttempts;
        }

        public void SetMessageHandler(Action<string> message)
        {
            MessageHandler = message;
        }

        public void Go()
        {
            // Creating task collection.
            Tasks = new Task[PlayerList.Count];
            for (int i = 0; i < PlayerList.Count; i++)
            {
                Tasks[0] = new Task(() => PlayerList[0].GetGuess(this), token);
            }
            foreach (var player in PlayerList)
            {
                Task.Run(() => player.GetGuess(this));
            }

            // Displaying game info (as a banner) in console.
            MessageHandler($"Guessed number is: {GuessedNumber}.");
            MessageHandler($"Basket borders: {MinBasketWeight }...{MaxBasketWeight}.\n");

            // Only one task can complete execution - it is a trigger,
            // and we will wait for it to exit to Main() and print a test tring in it.
            Task.WaitAny(Tasks.Where(i => i != null).ToArray());
        }


        public void AddPlayer(Player player)
        {
            PlayerList.Add(player);
        }

        public void AttemptProcessing(Attempt attempt)
        {
            lock (locker)
            {
                // Base recursion case.
                if (token.IsCancellationRequested)
                {
                    return;
                }
                
                // When attempts count reaches attempt capacity - game is finished,
                // cancellation token is activated.
                if (AvailableAttemptsCheck() == false)
                {
                    GameFinishing(); // Printing info of attempts of almost winners.
                    CTS.Cancel();
                    return;
                }

                AttemptList.Add(attempt);

                if (attempt.ChosedNumber == GuessedNumber)
                {
                    DisplayWinner();
                    CTS.Cancel();
                }
            }
        }

        private void GameFinishing()
        {
            MessageHandler($"  No winners...\n");
            int closestAttempt = AttemptList.OrderBy(i => Math.Abs(i.ChosedNumber - GuessedNumber)).ToList()[0].ChosedNumber;
            List<Attempt> almostWinnerList = AttemptList.OrderBy(i => Math.Abs(i.ChosedNumber - GuessedNumber)).TakeWhile(i => i.ChosedNumber == closestAttempt).ToList();

            if (almostWinnerList.Count == 1) { MessageHandler(" The closest attempt was:"); }
            else { MessageHandler(" The closest attempts were:"); }

            foreach (var attempt in almostWinnerList)
            {
                MessageHandler($"  {attempt.PlayerName}, {attempt.PlayerType}, ID {attempt.PlayerID}" +
                        $" - chosed number: {attempt.ChosedNumber}. ");
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
            return (AttemptList.Count <= MaxAttempts) ? true : false;
        }
    }
}
