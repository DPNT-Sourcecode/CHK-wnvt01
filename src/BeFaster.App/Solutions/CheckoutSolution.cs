using System;
using System.Collections.Generic;
using System.Linq;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions
{
    public static class MultiDealEngine
    {
        static List<MultiDeal> deals = new List<MultiDeal>();

        static MultiDealEngine()
        {
            deals.Add(new SimpleMultiBuyDeal(3, 130, 'A'));
            deals.Add(new SimpleMultiBuyDeal(5, 200, 'A'));
            deals.Add(new SimpleMultiBuyDeal(2, 45, 'B'));
            deals.Add(new MultiBuyRemovalDeal(2,'E', 1,'B'));
        }

        public static List<Tuple<MultiDeal, int>> FindDeals(char[] skus)
        {
            var foundDeals = new List<Tuple<MultiDeal, int>>();

            foreach (var multiDeal in deals)
            {
                var possibleApplications = multiDeal.CountNumberOfTimesCanBeApplied(skus);

                if(possibleApplications > 0)
                    foundDeals.Add(new Tuple<MultiDeal, int>(multiDeal, possibleApplications));
            }

            return foundDeals;
        } 
    }

    public static class CheckoutSolution
    {
        private static Dictionary<char, Product> Catalog;

        static CheckoutSolution()
        {
            Catalog = new Dictionary<char, Product>();
            Catalog.Add('A', new Product(50));
            Catalog.Add('B', new Product(30));
            Catalog.Add('C', new Product(20));
            Catalog.Add('D', new Product(15));
            Catalog.Add('E', new Product(40));
        }

        

        public static int Checkout(string skus)
        {
            try
            {
                var productsPurchased = skus.ToCharArray().OrderBy(x => x).ToArray();

                var total = 0;

                return total;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
