using System.Collections.Generic;

namespace GameFruitBasket.Classes
{
    public class CheaterPlayer : Player
    {
        //Читер – угадывает числа случайно, но не пробует варианты которые не получились у остальных игроков
        private EnumTypesOfPlayer _typeOfPlayer;

        public override EnumTypesOfPlayer TypeOfPlayer { get => _typeOfPlayer; set => _typeOfPlayer = EnumTypesOfPlayer.CheaterPlayer; }

        public List<int> cheaterTries;
        public CheaterPlayer(EnumTypesOfPlayer type, string name)
        {
            cheaterTries = new List<int>();
            StartRandom = 59;
            TypeOfPlayer = type;
            Name = name;
            AllLists.AddToCollection(cheaterTries);
            AllLists.AddToCollection(this);
        }

        public override int StartRandom { get; set; }

        internal override int GetNumber()
        {
            int number = 0;
            //bool InMemory = false;   
            do
            {
                Library.GetTryNumber(out number, StartRandom);
            }
            while (Library.CheckListForCheater(number) == true);
            Library.AddTryToList(number, cheaterTries);
            return number;
        }
    }
}
