using System;
using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions
{
    public static class MultiDealEngine
    {
        static List<IMultiDeal> deals = new List<IMultiDeal>();
        private static Dictionary<char, Product> Catalog = new Dictionary<char, Product>();

        static MultiDealEngine()
        {
            deals.Add(new SimpleMultiBuyDeal(3, 130, 'A'));
            deals.Add(new SimpleMultiBuyDeal(5, 200, 'A'));
            deals.Add(new SimpleMultiBuyDeal(2, 45, 'B'));
            deals.Add(new MultiBuyRemovalDeal(2,'E', 1,'B'));

            Catalog.Add('A', new Product(50));
            Catalog.Add('B', new Product(30));
            Catalog.Add('C', new Product(20));
            Catalog.Add('D', new Product(15));
            Catalog.Add('E', new Product(40));
        }

        public static List<Tuple<IMultiDeal, int>> FindDeals(char[] skus)
        {
            var foundDeals = new List<Tuple<IMultiDeal, int>>();

            foreach (var multiDeal in deals)
            {
                var possibleApplications = multiDeal.CountNumberOfTimesCanBeApplied(skus);

                if(possibleApplications > 0)
                    foundDeals.Add(new Tuple<IMultiDeal, int>(multiDeal, possibleApplications));
            }

            return foundDeals;
        }

        public static List<List<IMultiDeal>> ComputeCombinations(List<Tuple<IMultiDeal, int>> possibleDeals)
        {
            //if only one deal can be applied, just appliy it as many times as possible.
            if (possibleDeals.Count == 1)
                return new List < List < IMultiDeal >>
                {
                    Enumerable.Range(0, possibleDeals[0].Item2).Select(x => possibleDeals[0].Item1).ToList()
                };


            return new List<List<IMultiDeal>>();
        }

        public static int Apply(char[] productsPurchased)
        {
            throw new NotImplementedException();
        }
    }
}
