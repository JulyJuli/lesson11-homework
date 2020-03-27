using System.Collections.Generic;

namespace GameFruitBasket.Classes
{
    public static class AllLists
    {
        public static List<List<int>> allLists = new List<List<int>>();// коллекция проб всех игроков

        public static void AddToCollection(List<int> tries)
        {
            allLists.Add(tries);
        }

        public static List<Player> allPlayers = new List<Player>();// коллекция всех игроков

        public static List<Player> GetList()
        {
            return allPlayers;
        }

        public static void AddToCollection(Player player)
        {
            allPlayers.Add(player);
        }

    }
}
