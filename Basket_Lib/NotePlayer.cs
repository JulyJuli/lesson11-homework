using System;
using System.Collections.Generic;

namespace Basket_Lib
{
    public class NotePlayer : Player
    {
        private List<int> NoteList { get; set; }
        public NotePlayer(string name) : base(name)
        {
            NoteList = new List<int>();
        }

        public override int GetGuess(Game game)
        {
            int result = Random.Next(game.MinBasketWeight, game.MaxBasketWeight + 1);

            if (!NoteList.Contains(result))
            {
                NoteList.Add(result);
                game.AttemptList.Add(new Attempt(this, result));
                return result;
            }
            return GetGuess(game);
        }
    }
}
