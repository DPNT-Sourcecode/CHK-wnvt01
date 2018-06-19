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
                var runningPrice = 0;
                for (var j = 0; j < NumberRequired; j++)
                {
                    runningPrice += prices[i++];
                }
                saving = runningPrice - Price;
            } while (i + (NumberRequired - 1) < prices.Count);


            return saving;
        }

        public Tuple<char[], int> Apply(char[] characters)
        {
            List<char> prices = new List<char>();

            foreach (var product in Products)
            {
                var numberOfProduct = characters.Count(x => x == product);
                prices.AddRange(Enumerable.Repeat(product, numberOfProduct));

            }

            if (prices.Count < NumberRequired)
                return new Tuple<char[], int>(characters, 0);

            var caseCharacters = characters.ToArray();

            for (int i = 0; i < NumberRequired; i++)
            {
                caseCharacters.Where(x => x == prices[i])

            }



        }

        public int Saving { get; }
    }
}
