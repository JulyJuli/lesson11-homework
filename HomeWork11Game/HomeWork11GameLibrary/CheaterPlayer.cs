using System.Collections.Generic;

namespace HomeWork11GameLibrary
{
    public class CheaterPlayer : Player
    {

        public CheaterPlayer(string name, TypeOfPlayer typeOfPlayer) : base(name, typeOfPlayer)
        {
            CheaterGuessed = new List<int>();
        }

        public List<int> CheaterGuessed { get; set; }

        public override int Guessing()
        {
            int countOfGuess;

            do
            {
                countOfGuess = 0;
                Guessed = base.Guessing();
                for (int i = 0; i < AllListsNumbers.Count; i++)
                {
                    for (int j = 0; j < AllListsNumbers[i].Count; j++)
                    {
                        if (Guessed == AllListsNumbers[i][j])
                        {
                            countOfGuess++;
                        }
                    }
                }
            }
            while (countOfGuess != 0);

            return Guessed;
        }
    }
}
