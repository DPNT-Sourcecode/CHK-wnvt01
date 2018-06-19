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

                if (foundPossibleDeals.Count == 0)
                {
                    return MultiDealEngine.SimplePricing(productsPurchased);
                }

                var dealsOrderedInValue =  foundPossibleDeals.OrderBy(x => x.Item1.Saving).ToList();

                return MultiDealEngine.ApplyHighValueDealsInOrder(dealsOrderedInValue, productsPurchased);

            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
