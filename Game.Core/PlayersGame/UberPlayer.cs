namespace Game.PlayersGame
{
    public class UberPlayer : Players
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int LastGuessed { get; set; }

        public UberPlayer(string name) : base(name)
        {
            Start = MinWeight;
            End = MaxWeight;
        }

        public override int Guess()
        {
            this.Sleep();

            if (LastGuessed == 0)
            {
                LastGuessed = Start;
            }
            else if (LastGuessed < End)
            {
                LastGuessed++;
            }

            Answers.Add(LastGuessed);

            return LastGuessed;
        }
    }
}