using System.Collections.Generic;

namespace HomeWork11GameLibrary
{
    public class OrdinaryPlayer : Player
    {

        public OrdinaryPlayer(string name, TypeOfPlayer typeOfPlayer) : base(name, typeOfPlayer)
        {
            OrdinaryGuessed = new List<int>();
        }
        public List<int> OrdinaryGuessed { get; set; }
    }
}
