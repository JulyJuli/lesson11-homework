using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFruitBasket.Classes
{
    public class UberCheaterPlayer : Player
    {
        //Убер-читер – идет по порядку, но пропускает опробованные другими игроками варианты
        private EnumTypesOfPlayer _typeOfPlayer;        
        public override EnumTypesOfPlayer TypeOfPlayer { get => _typeOfPlayer; set => _typeOfPlayer = EnumTypesOfPlayer.UberCheaterPlayer; }
         
        public List<int> uberCheaterTries;
        public UberCheaterPlayer(EnumTypesOfPlayer type, string name)
        {
            uberCheaterTries = new List<int>();
            StartRandom = 108;
            TypeOfPlayer = type;
            Name = name;
            LastAnswer = 40;
            AllLists.AddToCollection(uberCheaterTries);
            AllLists.AddToCollection(this);
        }

        public override int StartRandom { get; set; }

        public int LastAnswer { get; set; }
        internal override int GetNumber()
        {
            int number = LastAnswer;
            do
            {
                ++LastAnswer;
                number = LastAnswer;
                
                Library.CheckListForCheater(number);
            } while (Library.CheckListForCheater(number) == true);
            Library.AddTryToList(number, uberCheaterTries);

            return number;
        }
    }
}
