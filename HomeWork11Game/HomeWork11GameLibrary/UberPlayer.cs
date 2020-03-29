using System.Collections.Generic;

namespace HomeWork11GameLibrary
{
    public class UberPlayer : Player
    {
        public UberPlayer(string name, TypeOfPlayer typeOfPlayer) : base(name, typeOfPlayer)
        {
            UberGuessed = new List<int>();
        }

        public List<int> UberInitialized = new List<int>();
        public List<int> UberGuessed { get; set; }

        public override int Guessing()
        {
            Guessed = UberInitialized[0];
            UberInitialized.RemoveAt(0);

            return Guessed;
        }
    }
}
