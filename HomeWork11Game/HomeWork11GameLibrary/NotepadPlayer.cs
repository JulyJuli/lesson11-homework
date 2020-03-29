using System.Collections.Generic;

namespace HomeWork11GameLibrary
{
    public class NotepadPlayer : Player
    {
        public NotepadPlayer(string name, TypeOfPlayer typeOfPlayer) : base(name, typeOfPlayer)
        {
            NotepadGuessed = new List<int>();
        }

        public List<int> NotepadGuessed { get; set; }

        public override int Guessing()
        {
            int countOfGuess;

            do
            {
                countOfGuess = 0;
                int isGuessed = base.Guessing();
                for (int i = 0; i < NotepadGuessed.Count; i++)
                {
                    if (isGuessed == NotepadGuessed[i])
                    {
                        countOfGuess++;
                    }
                }
            }
            while (countOfGuess != 0);

            return Guessed;
        }
    }
}

