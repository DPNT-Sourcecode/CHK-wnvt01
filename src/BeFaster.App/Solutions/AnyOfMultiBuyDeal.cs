using System;

namespace BeFaster.App.Solutions
{
    public class AnyOfMultiBuyDeal : IMultiDeal
    {
        public AnyOfMultiBuyDeal(int i, int price, params char[] c)
        {

        }

        public int CalculatePossibleSavings(char[] characters)
        {
            throw new NotImplementedException();
        }

        public Tuple<char[], int> Apply(char[] characters)
        {
            throw new NotImplementedException();
        }

        public int Saving { get; }
    }
}
