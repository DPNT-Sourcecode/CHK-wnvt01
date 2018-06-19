using System;
using System.Collections.Generic;
using System.Linq;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions
{
    public static class CheckoutSolution
    {
        public static int Checkout(string skus)
        {
            try
            {
                var productsPurchased = skus.ToCharArray().OrderBy(x => x).ToArray();
                var foundPossibleDeals = MultiDealEngine.FindDeals(productsPurchased);
                var combinations = MultiDealEngine.ComputeCombinations(foundPossibleDeals);

                if (combinations.Count == 0)
                {
                    return MultiDealEngine.SimplePricing(productsPurchased);
                }

                return combinations.Select(x => MultiDealEngine.Apply(x, foundPossibleDeals, productsPurchased)).AsParallel().Min();
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
