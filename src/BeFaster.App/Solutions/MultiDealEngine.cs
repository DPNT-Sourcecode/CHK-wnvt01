using System;
using System.Collections.Generic;

namespace BeFaster.App.Solutions
{
    public static class MultiDealEngine
    {
        static List<MultiDeal> deals = new List<MultiDeal>();
        private static Dictionary<char, Product> Catalog;

        static MultiDealEngine()
        {
            deals.Add(new SimpleMultiBuyDeal(3, 130, 'A'));
            deals.Add(new SimpleMultiBuyDeal(5, 200, 'A'));
            deals.Add(new SimpleMultiBuyDeal(2, 45, 'B'));
            deals.Add(new MultiBuyRemovalDeal(2,'E', 1,'B'));
            Catalog = new Dictionary<char, Product>();
            Catalog.Add('A', new Product(50));
            Catalog.Add('B', new Product(30));
            Catalog.Add('C', new Product(20));
            Catalog.Add('D', new Product(15));
            Catalog.Add('E', new Product(40));
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

        public static List<List<MultiDeal>> ComputeCombinations(List<Tuple<MultiDeal, int>> possibleDeals)
        {
            return new List<List<MultiDeal>>();
        }

        public static int Apply(char[] productsPurchased)
        {
            throw new NotImplementedException();
        }
    }
}