
using System.Collections.Generic;

namespace GameWithBasket
{
    public class UberPlayer : Player
    {
        int startValue = minValue;
        internal override string TypeName { get => "UberPlayer"; }

        public override int GetValue(List<int> trials)
        {  
            return startValue++;
        }
    }
}
