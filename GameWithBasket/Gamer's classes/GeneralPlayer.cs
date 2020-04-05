using System;
using System.Collections.Generic;


namespace GameWithBasket
{
    public class GeneralPlayer: Player
    {
        internal override string TypeName { get => "GeneralPlayer"; }
        public override int GetValue(List<int> trials)
        {
            return new Random().Next(minValue, maxValue);
        }

    }
}
