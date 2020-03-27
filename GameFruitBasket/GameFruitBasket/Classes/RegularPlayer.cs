using System.Collections.Generic;

namespace GameFruitBasket.Classes
{
    public class RegularPlayer : Player
    {
        private EnumTypesOfPlayer _typeOfPlayer;
        public List<int> regularsTries;
        public RegularPlayer(EnumTypesOfPlayer type, string name)
        {
            regularsTries = new List<int>();
            StartRandom = 19;
            TypeOfPlayer = type;
            Name = name;
            AllLists.AddToCollection(regularsTries);
            AllLists.AddToCollection(this);
        }
        public override EnumTypesOfPlayer TypeOfPlayer { get => _typeOfPlayer; set => _typeOfPlayer = EnumTypesOfPlayer.RegularPlayer; }
        public override int StartRandom { get; set; }
        internal override int GetNumber()
        {
            Library.GetTryNumber(out int number, StartRandom);
            Library.AddTryToList(number, regularsTries);
            return number;
        }
    }
}
