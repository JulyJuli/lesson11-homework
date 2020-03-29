using System;
using System.Collections.Generic;
using System.Linq;
using static Basket_Lib.DelegateHolder;

namespace Basket_Lib
{
    public class Game
    {
        public List<Attempt> AttemptList { get; private set; } = new List<Attempt>();
        public List<Player> PlayerList { get; private set; } = new List<Player>();
        public int MaxBasketWeight { get; private set; }
        public int MinBasketWeight { get; private set; }
        private ShowMessage MessageHandler { get; set; }
        public int GuessedNumber { get; private set; }


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
            int pointer = 0;

            MessageHandler($"Guessed number is: {GuessedNumber}.");
            MessageHandler($"Basket borders: {MinBasketWeight }...{MaxBasketWeight}.\n");

            for (int i = 0; i < AttemptList.Capacity; i++)
            {
                GetPlayer(ref pointer).GetGuess(this);
                if (AttemptList.Last().ChosedNumber == GuessedNumber)
                {
                    MessageHandler($"The winner is {GetWinner().PlayerName} (id \"{GetWinner().PlayerID}\")," +
                        $" {GetWinner().PlayerType.ToLower()}, with number {GetWinner().ChosedNumber}!!! ");
                    return;
                }
            }


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
        private Player GetPlayer(ref int index)
        {
            if (index >= PlayerList.Count) { index = 0; }

            return PlayerList[index++];
        }

        public void AddPlayer(Player player)
        {
            PlayerList.Add(player);
        }

        private Attempt GetWinner()
        {
            return AttemptList.Last();
        }
    }
}
