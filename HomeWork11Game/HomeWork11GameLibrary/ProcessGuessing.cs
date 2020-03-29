using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11GameLibrary
{
    public class ProcessGuessing
    {
        public Player Player { get; set; }

        public int Weight { get; set; }

        public ProcessGuessing(Player player, int weight)
        {
            Player = player;
            Weight = weight;
        }

        public static List<ProcessGuessing> allPlayersAndGuessings = new List<ProcessGuessing>();

        public static void AddPlayerAndWeight(ProcessGuessing playerAndWeight)
        {
            allPlayersAndGuessings.Add(playerAndWeight);
        }

        public override string ToString()
        {
            return Player.ToString();
        }
    }
}
