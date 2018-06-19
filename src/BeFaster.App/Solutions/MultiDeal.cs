using System;

namespace BeFaster.App.Solutions
{
    public abstract class MultiDeal
    {
        public abstract int CountNumberOfTimesCanBeApplied(char[] characters);
        public abstract Tuple<char[], int> Apply(char[] characters);
    }
}
