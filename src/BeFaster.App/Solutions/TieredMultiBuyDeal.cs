using System;
using System.Linq;

namespace BeFaster.App.Solutions
{
    public class TieredMultiBuyDeal : IMultiDeal
    {
        public SimpleMultiBuyDeal A { get; }
        public SimpleMultiBuyDeal B { get; }

        public TieredMultiBuyDeal(SimpleMultiBuyDeal A, SimpleMultiBuyDeal B)
        {
            if(A.Character != B.Character)
                throw new Exception("Cant tier");
            if (A.Saving > B.Saving)
            {
                this.A = A;
                this.B = B;
            }
            else
            {
                this.B = A;
                this.A = B;
            }
        }

        public int CalculatePossibleSavings(char[] characters)
        {
            var amount = characters.Count(x => A.Character == x);

            var aApplies = amount / A.Quantity;

            var savingsFromA = A.Saving * aApplies;

            var bAmount = amount - aApplies * A.Quantity;

            var bApplies = bAmount / B.Quantity;

            var savingsFromB = B.Saving * bApplies;

            return savingsFromA + savingsFromB;
        }

        public Tuple<char[], int> Apply(char[] characters)
        {
            var aApplied = A.Apply(characters);
            if (aApplied.Item2 != 0)
                return aApplied;

            return B.Apply(characters);
        }

        public int Saving { get; }
    }
}