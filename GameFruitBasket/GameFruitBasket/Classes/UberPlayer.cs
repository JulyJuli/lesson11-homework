using System.Collections.Generic;

namespace GameFruitBasket.Classes
{
    public class UberPlayer : Player
    {
        //Убер-игрок - идет по порядку, 40, 41, 42, 43…

        private EnumTypesOfPlayer _typeOfPlayer;

        public List<int> uberTries;
        public UberPlayer(EnumTypesOfPlayer type, string name)//
        {
            uberTries = new List<int>();
            StartRandom = 72;
            TypeOfPlayer = type;
            Name = name;
            LastAnswer = 39;
            AllLists.AddToCollection(uberTries);
            AllLists.AddToCollection(this);
        }

        public override int StartRandom { get; set; }
        public override EnumTypesOfPlayer TypeOfPlayer { get => _typeOfPlayer; set => _typeOfPlayer = EnumTypesOfPlayer.UberPlayer; }
        public int LastAnswer { get; set; }
        public void AddTryToList(int number)
        {
            uberTries.Add(number);
        }

        internal override int GetNumber()
        {
            ++LastAnswer;
            int number = LastAnswer;
            AddTryToList(number);
            return number;
        }
    }
}
