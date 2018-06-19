using System;
using System.Linq;

namespace BeFaster.App.Solutions
{
    public class BuyXGetXFreeDeal : IMultiDeal
    {
        public int AddingQuantity { get; }
        public char Character { get; }
        public int RemovesQuantity { get; }
        public int Price { get; }

        public BuyXGetXFreeDeal(char character, int addingQuantity,  int removesQuantity, int price)
        {
            AddingQuantity = addingQuantity;
            Character = character;
            RemovesQuantity = removesQuantity;
            Price = price;
        }


        public int CountNumberOfTimesCanBeApplied(char[] characters)
        {
            return characters.Count(y => y == Character) / (AddingQuantity+RemovesQuantity);
        }

        public Tuple<char[], int> Apply(char[] characters)
        {
            if (characters.Count(y => y == Character) < (AddingQuantity + RemovesQuantity))
                return new Tuple<char[], int>(characters, 0);

            var remainingDealTriggers = characters
                .Where(y => y == Character).Skip(AddingQuantity + RemovesQuantity).ToArray();

            var resultingObject = characters.Where(y => y != Character)
                .Concat(remainingDealTriggers).Concat(remainingDealTriggers).OrderBy(y => y).ToArray();

            return new Tuple<char[], int>(resultingObject, Price);
        }
    }
}
