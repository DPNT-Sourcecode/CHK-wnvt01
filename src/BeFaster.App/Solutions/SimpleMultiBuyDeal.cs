using System;
using System.Linq;

namespace BeFaster.App.Solutions
{
    public class SimpleMultiBuyDeal : MultiDeal
    {
        public int Quantity { get; }
        public int Price { get; }
        public char Character { get; }

        public SimpleMultiBuyDeal(int quantity, int price, char character)
        {
            Quantity = quantity;
            Price = price;
            Character = character;
        }

        public override int CountNumberOfTimesCanBeApplied(char[] characters)
            => characters.Count(y => y == Character) / Quantity;

        public override Tuple<char[], int> Apply(char[] characters)
        {
            if (characters.Count(y => y == Character) < Quantity)
                return new Tuple<char[], int>(characters, 0);

            var remainingAs = characters.Where(y => y == Character).Skip(Quantity).ToArray();
            var resultingObject = characters.Where(y => y != Character).Concat(remainingAs).OrderBy(y => y).ToArray();

            return new Tuple<char[], int>(resultingObject, Price);
        }
    }
}