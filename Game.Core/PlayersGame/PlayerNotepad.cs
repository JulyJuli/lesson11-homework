using System.Collections.Generic;

namespace Game.PlayersGame
{
    public class PlayerNotepad : Players
    {
        public List<int> WrongNumber { get; set; }

        public PlayerNotepad(string name) : base(name)
        {
            WrongNumber = new List<int>();
        }

        public override int Guess()
        {
            this.Sleep();

            int result;
            do
            {
                result = PrintGuess();
            }
            while (WrongNumber.Contains(result));
            Answers.Add(result);
            return result;
        }
    }
}