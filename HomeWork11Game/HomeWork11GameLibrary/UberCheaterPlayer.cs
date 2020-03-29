using System.Collections.Generic;

namespace HomeWork11GameLibrary
{
    public class UberCheaterPlayer : Player
    {
        public UberCheaterPlayer(string name, TypeOfPlayer typeOfPlayer) : base(name, typeOfPlayer)
        {
            UberCheaterGuessed = new List<int>();
        }

        public List<int> UberCheaterInitialized = new List<int>();

        public List<int> UberCheaterGuessed;

        public override int Guessing()
        {
            int countOfGuess;
            int k = 0;
            do
            {
                countOfGuess = 0;
                Guessed = UberCheaterInitialized[k];

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
                k++;
            }
            while (countOfGuess != 0);

            return Guessed;
        }
    }
}
