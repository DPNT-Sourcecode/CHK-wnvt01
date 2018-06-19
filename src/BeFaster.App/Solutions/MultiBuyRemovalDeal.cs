using System;
using System.Linq;

namespace BeFaster.App.Solutions
{
    public class MultiBuyRemovalDeal : IMultiDeal
    {
        public int AddingQuantity { get; }
        public char AddingCharacter { get; }
        public int RemovesQuantity { get; }
        public char RemovesCharacter { get; }
        public int Price { get; }
        public int Saving { get; }

        public MultiBuyRemovalDeal(int addingQuantity, char addingCharacter, int removesQuantity, char removesCharacter)
        {
            AddingQuantity = addingQuantity;
            AddingCharacter = addingCharacter;
            RemovesQuantity = removesQuantity;
            RemovesCharacter = removesCharacter;
            Price = MultiDealEngine.Catalog[addingCharacter].Price * addingQuantity;
            Saving = RemovesQuantity * MultiDealEngine.Catalog[removesCharacter].Price;
        }


        public int CalculatePossibleSavings(char[] characters)
        {
            return characters.Count(y => y == AddingCharacter) / AddingQuantity;
        }

        public Tuple<char[], int> Apply(char[] characters)
        {
            if (characters.Count(y => y == AddingCharacter) < AddingQuantity || characters.Count(y => y == RemovesCharacter) < RemovesQuantity)
                return new Tuple<char[], int>(characters, 0);

            var remainingDealTriggers = characters
                .Where(y => y == AddingCharacter).Skip(AddingQuantity).ToArray();
            var remainingDealRemovals = characters
                .Where(y => y == RemovesCharacter).Skip(RemovesQuantity).ToArray();

            var resultingObject = characters.Where(y => y != AddingCharacter && y != RemovesCharacter)
                .Concat(remainingDealRemovals).Concat(remainingDealTriggers).OrderBy(y => y).ToArray();

            return new Tuple<char[], int>(resultingObject, Price);
        }
    }
}
