namespace Game.Game
{
    public class Result
    {
        public Result()
        {
            Nearest = new PlayerGuess();
        }

        public int RealWeight { get; set; }

        public string WonPlayerName { get; set; }

        public PlayerGuess Nearest { get; set; }
    }

    public class PlayerGuess
    {
        public string Name { get; set; }

        public int Guess { get; set; }
    }
}