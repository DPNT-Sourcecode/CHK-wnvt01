using System;
using System.Linq;

namespace BeFaster.App.Solutions
{
    public class MultiBuyRemovalDeal : MultiDeal
    {
        public int AddingQuantity { get; }
        public char AddingCharacter { get; }
        public int RemovesQuantity { get; }
        public char RemovesCharacter { get; }

        public MultiBuyRemovalDeal(int addingQuantity, char addingCharacter, int removesQuantity, char removesCharacter)
        {
            AddingQuantity = addingQuantity;
            AddingCharacter = addingCharacter;
            RemovesQuantity = removesQuantity;
            RemovesCharacter = removesCharacter;
        }

        public override int CountNumberOfTimesCanBeApplied(char[] characters)
        {
            return Math.Min(characters.Count(y => y == AddingCharacter) / AddingQuantity, characters.Count(y => y == RemovesCharacter) / RemovesQuantity);
        }

        public override Tuple<char[], int> Apply(char[] characters)
        {
            throw new NotImplementedException();
        }
    }
}
