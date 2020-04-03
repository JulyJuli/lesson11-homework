
namespace Poslednjaja_popytka
{
    public class ProcessGuessing
    {        
        public ProcessGuessing(BasePlayer player, int weight)
        {
            Player = player;
            Weight = weight;
        }

        public BasePlayer Player { get; set; }
        public int Weight { get; set; }
        public override string ToString()
        {
            return Player.ToString();
        }
    }
}
