using System;
using System.Collections.Generic;
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
            var saving = 0;

            List<int> prices = new List<int>();

            foreach (var product in Products)
            {
                var numberOfProduct = characters.Count(x => x == product);
                prices.AddRange(Enumerable.Repeat(MultiDealEngine.Catalog[product].Price, numberOfProduct));
            }

            if (prices.Count < 3)
                return 0;

            var i = 0;
            do
            {
                var runningPrice = prices[i++];
                runningPrice += prices[i++];
                runningPrice += prices[i++];
                saving = runningPrice - Price;
            } while (i + 2 < prices.Count);


            return saving;
        }

        public Tuple<char[], int> Apply(char[] characters)
        {
            throw new NotImplementedException();
        }

        public int Saving { get; }
    }
}
