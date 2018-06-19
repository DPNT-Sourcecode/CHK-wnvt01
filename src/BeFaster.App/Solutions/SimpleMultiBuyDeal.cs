using System;
using System.Linq;

namespace BeFaster.App.Solutions
{
    public class SimpleMultiBuyDeal : MultiDeal
    {
        public SimpleMultiBuyDeal(int quantity, int price, char character)
        {
            CountNumberOfTimesCanBeApplied = x => x.Count(y => y == character) / quantity;
            Apply = x =>
            {
                if (x.Count(y => y == character) < quantity)
                    return new Tuple<char[], int>(x, 0);

                var remainingAs = x.Where(y => y == character).Skip(quantity).ToArray();
                var resultingObject = x.Where(y => y != character).Concat(remainingAs).OrderBy(y => y).ToArray();

                return new Tuple<char[], int>(resultingObject, price);
            };
        }
    }
}
