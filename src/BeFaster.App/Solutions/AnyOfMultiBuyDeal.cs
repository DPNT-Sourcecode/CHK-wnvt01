using System;
using System.Linq;

namespace BeFaster.App.Solutions
{
    public class AnyOfMultiBuyDeal : IMultiDeal
    {
        public char[] Products { get; }
        public int NumberRequired { get; }
        public int Price { get; }

        public AnyOfMultiBuyDeal(int i, int price, params char[] c)
        {
            Products = c.OrderByDescending(x => MultiDealEngine.Catalog[x].Price).ToArray();
            NumberRequired = i;
            Price = price;
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
