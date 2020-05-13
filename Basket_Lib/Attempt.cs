namespace Basket_Lib
{
    public class Attempt
    {
        public string PlayerType { get; private set; }
        public int PlayerID { get; private set; }
        public string PlayerName { get; private set; }
        public int ChosedNumber { get; private set; }

        public Attempt(Player player, int chosedNumber)
        {
            PlayerType = player.GetType().Name;
            PlayerID = Player.ID;
            PlayerName = player.Name;
            ChosedNumber = chosedNumber;
        }
    }
}
