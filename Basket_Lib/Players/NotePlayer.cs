using System;
using System.Collections.Generic;
using System.Linq;

namespace Basket_Lib
{
    public class NotePlayer : Player
    {
        private List<int> NoteList { get; set; }


        public NotePlayer(string name) : base(name)
        {
            NoteList = new List<int>();
        }


        public override int GetNumber(Game game)
        {
            int result = Random.Next(game.MinBasketWeight, game.MaxBasketWeight + 1);

            if (!NoteList.Contains(result))
            {
                NoteList.Add(result);
                return result;
            }
            return GetNumber(game);
        }
    }
}

