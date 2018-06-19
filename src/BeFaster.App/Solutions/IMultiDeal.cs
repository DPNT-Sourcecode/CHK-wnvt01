using System;

namespace BeFaster.App.Solutions
{
    public interface IMultiDeal
    {
        int CalculatePossibleSavings(char[] characters);
        Tuple<char[], int> Apply(char[] characters);
        int Saving { get; }
    }
}
