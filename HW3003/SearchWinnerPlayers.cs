using System;
using System.Collections.Generic;
using System.Linq;

namespace HW3003
{
    public class SearchWinnerPlayers
    {
        public SearchWinnerPlayers (string name, int number)
        {
            Name = name;
            Number = number;
        }
        
        string Name { get; set; }
        int Number { get; set; }

        public string NamePlayer()
        {
            return Name;
        }
        public int NumberPlayer()
        {
            return Number;
        }
        
        public override string ToString()
        {
            return $"Name type: {NamePlayer()}, Number: {NumberPlayer()}";
        }
        public static void SearchNumber(List<SearchWinnerPlayers> players, int basketWeight)
        {
            int result = 0;
            Console.WriteLine($"\nBasket weight: {basketWeight}\n");
            List<int> num = new List<int>();
            for (int i = 0; i < players.Count; i++)
            {
                result = Math.Abs(basketWeight - players[i].NumberPlayer());
                num.Add(result);

            }
            Console.WriteLine("Winner players: \n");
            for (int i = 0; i < players.Count; i++)
            {
                if (num.Min() == num[i])
                {
                    Console.WriteLine($"{players[i].ToString()}\n");
                }
            }
            //int index = num.IndexOf(num.Min());
            //Console.WriteLine($"\n{ play[index].ToString()}");
        }

    }
}
