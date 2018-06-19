using System;
using System.Linq;

namespace BeFaster.App.Solutions
{
    public class SimpleMultiBuyDeal : IMultiDeal
    {
        public int Quantity { get; }
        public int Price { get; }
        public char Character { get; }
        public int Saving { get; }

        public SimpleMultiBuyDeal(int quantity, int price, char character)
        {
            Quantity = quantity;
            Price = price;
            Character = character;
            Saving = quantity * MultiDealEngine.Catalog[character].Price - price;
        }

        public int CountNumberOfTimesCanBeApplied(char[] characters)
            => characters.Count(y => y == Character) / Quantity;

        public Tuple<char[], int> Apply(char[] characters)
        {
            if (characters.Count(y => y == Character) < Quantity)
                return new Tuple<char[], int>(characters, 0);

            var remainingAfterDeal = characters.Where(y => y == Character).Skip(Quantity).ToArray();
            var resultingObject = characters.Where(y => y != Character).Concat(remainingAfterDeal).OrderBy(y => y).ToArray();

            return new Tuple<char[], int>(resultingObject, Price);
        }
    }
}