using Game.Interface;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Game.PlayersGame
{
    public abstract class Players : IGuess
    {
        private static Random random = new Random();
        public List<int> Answers;

        public static int MinWeight = 40;
        public static int MaxWeight = 140;


        public Players(string name)
        {
            Name = name;
            Answers = new List<int>();
        }

        public string Name { get; set; }

        public int InputRandom { get; set; }
        public string TypePlayer { get; set; }
        public DateTime LastGuess { get; private set; }
        public int WaitingTime { get; set; }


        public void AddWaitTime(int timeToWait)
        {
            LastGuess = DateTime.Now;
            WaitingTime = timeToWait;
        }
        public override string ToString()
        {
            return $"{ Name}, {TypePlayer}";
        }

        protected void Sleep()
        {
            Thread.Sleep(WaitingTime);
        }

        public static int PrintGuess()
        {
            return random.Next(MinWeight, MaxWeight + 1);
        }

        public abstract int Guess();
    }
}