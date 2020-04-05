
using System.Collections.Generic;

namespace GameWithBasket
{
    public class CurrentGame
    {
        public List<int> allTrials;
        public string PotentialWinner { get; set; }
        public int NearestValue { get; set; }

        public CurrentGame ()
        {
            allTrials = new List<int>();
        }

      

    }
}
