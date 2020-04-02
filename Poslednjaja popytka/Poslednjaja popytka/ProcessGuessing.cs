
namespace Poslednjaja_popytka
{
    public class ProcessGuessing
    {
        public BasePlayer Player { get; set; }

        public int Weight { get; set; }

        public ProcessGuessing(BasePlayer player, int weight)
        {
            Player = player;
            Weight = weight;
        }

        public override string ToString()
        {
            return Player.ToString();
        }
    }
}
