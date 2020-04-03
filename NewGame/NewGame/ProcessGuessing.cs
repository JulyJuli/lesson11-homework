using NewGame.Players;
using System;
using System.Collections.Generic;

namespace NewGame
{
    class ProcessGuessing
    {
        public static List<ProcessGuessing> allPlayersAndGuessings = new List<ProcessGuessing>();

        public ProcessGuessing(BasePlayer player, int weight)
        {
            Player = player;
            Weight = weight;
        }

        public BasePlayer Player { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{Player.TypeOfPlayer} WIN {Weight}!!!!!";
        }

        public static void PrintList()
        {
            for (int i = 0; i < allPlayersAndGuessings.Count; i++)
            {
                Console.Write(allPlayersAndGuessings[i].Weight + " ");
            }
        }
    }
}
