using System;

namespace BeFaster.App.Solutions
{
    public interface IMultiDeal
    {
        int CountNumberOfTimesCanBeApplied(char[] characters);
        Tuple<char[], int> Apply(char[] characters);
    }
}
