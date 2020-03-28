using System.Collections.Generic;
using Game.interfaces;

namespace Game.classes
{
    public abstract class Player : IHuman
    {
        public const int MIN_VALUE = 40;
        public const int MAX_VALUE = 140;
        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public virtual int GetNumber(List<int> attempts)
        {
            return 0;
        }

        public override string ToString()
        {
            return $"Name = {Name}";
        }
    }
}