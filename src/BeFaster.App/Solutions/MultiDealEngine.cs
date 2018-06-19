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

        public static List<List<int>> ComputeCombinations(List<Tuple<IMultiDeal, int>> possibleDeals)
        {
            //if only one deal can be applied, just appliy it as many times as possible.
            if (possibleDeals.Count == 1)
                return new List<List<int>>
                {
                    Enumerable.Range(0, possibleDeals[0].Item2).Select(x => 0).ToList()
                };

            var baseCombination = new List<int>();

            for (var i = 0; i < possibleDeals.Count; i++)
            {
                baseCombination.AddRange(Enumerable.Range(0, possibleDeals[i].Item2).Select(_ => i));
            }

            var resultSet = new List<List<int>>();

            var currentState = baseCombination.ToArray();
            resultSet.Add(currentState.ToList());

            //heaps algorithm -- non-recursive
            var state = Enumerable.Range(0, baseCombination.Count).Select(_ => 0).ToArray();

            var j = 0;

            do
            {
                if (state[j] < j)
                {
                    if (j % 2 == 0)
                    {
                        Swap(0, j, currentState);
                    }
                    else
                    {
                        Swap(state[j], j, currentState);
                    }
                    resultSet.Add(currentState.ToList());
                    state[j] += 1;
                    j = 0;
                }
                else
                {
                    state[j] = 0;
                    j++;
                }
            } while (j < baseCombination.Count);

            return resultSet;
        }

        public static void Swap(int l, int r, int[] array)
        {
            var oldL = array[l];

            array[l] = array[r];
            array[r] = oldL;
        }

        public static int Apply(List<int> dealIndexes, List<Tuple<IMultiDeal,int>> availableDeals, char[] productsPurchased)
        {
            var caseProducts = new char[productsPurchased.Length];
            productsPurchased.CopyTo(caseProducts, 0);
            var total = 0;

            foreach (var dealIndex in dealIndexes)
            {
                var res = availableDeals[dealIndex].Item1.Apply(productsPurchased);
                caseProducts = res.Item1;
                total += res.Item2;
            }

            foreach (var product in caseProducts)
            {
                total += Catalog[product].Price;
            }

            return total;
        }
    }
}