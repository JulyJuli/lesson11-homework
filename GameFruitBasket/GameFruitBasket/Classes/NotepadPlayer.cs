using System.Collections.Generic;

namespace GameFruitBasket.Classes
{
    public class NotepadPlayer : Player
    {
        //Игрок-блокнот – также угадывает случайно, но не повторяет один и тот же выбор дважды
        private EnumTypesOfPlayer _typeOfPlayer;
        public override EnumTypesOfPlayer TypeOfPlayer
        {
            get => _typeOfPlayer; set => _typeOfPlayer = EnumTypesOfPlayer.NotepadPlayer;
        }
        public List<int> notepadsTries;
        public NotepadPlayer(EnumTypesOfPlayer type, string name)
        {
            notepadsTries = new List<int>();
            StartRandom = 28;
            TypeOfPlayer = type;
            Name = name;
            AllLists.AddToCollection(notepadsTries);
            AllLists.AddToCollection(this);
        }

        public override int StartRandom { get; set; }

        public bool CheckList(int number)
        {
            bool InMemory = false;
            for (int i = 0; i < notepadsTries.Count; i++)
            {
                if (notepadsTries[i].Equals(number))
                {
                    InMemory = true;
                }
            }

            return InMemory;
        }

        internal override int GetNumber()
        {
            int number;
            do
            {
                Library.GetTryNumber(out number, StartRandom);
            }
            while (CheckList(number) != false);
            Library.AddTryToList(number, notepadsTries);
            return number;
        }
    }
}
