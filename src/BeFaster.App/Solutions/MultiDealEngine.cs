using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BeFaster.App.Solutions
{
    public static class MultiDealEngine
    {
        static List<IMultiDeal> deals = new List<IMultiDeal>();
        public static Dictionary<char, Product> Catalog = new Dictionary<char, Product>();

        static MultiDealEngine()
        {
            Catalog.Add('A', new Product(50));
            Catalog.Add('B', new Product(30));
            Catalog.Add('C', new Product(20));
            Catalog.Add('D', new Product(15));
            Catalog.Add('E', new Product(40));
            Catalog.Add('F', new Product(10));
            Catalog.Add('G', new Product(20));
            Catalog.Add('H', new Product(10));
            Catalog.Add('I', new Product(35));
            Catalog.Add('J', new Product(60));
            Catalog.Add('K', new Product(80));
            Catalog.Add('L', new Product(90));
            Catalog.Add('M', new Product(15));
            Catalog.Add('N', new Product(40));
            Catalog.Add('O', new Product(10));
            Catalog.Add('P', new Product(50));
            Catalog.Add('Q', new Product(30));
            Catalog.Add('R', new Product(50));
            Catalog.Add('S', new Product(30));
            Catalog.Add('T', new Product(20));
            Catalog.Add('U', new Product(40));
            Catalog.Add('V', new Product(50));
            Catalog.Add('W', new Product(20));
            Catalog.Add('X', new Product(90));
            Catalog.Add('Y', new Product(10));
            Catalog.Add('Z', new Product(50));


            deals.Add(new SimpleMultiBuyDeal(3, 130, 'A'));
            deals.Add(new SimpleMultiBuyDeal(5, 200, 'A'));
            deals.Add(new SimpleMultiBuyDeal(2, 45, 'B'));
            deals.Add(new MultiBuyRemovalDeal(2,'E', 1,'B'));
            deals.Add(new BuyXGetXFreeDeal('F', 2, 1));
            deals.Add(new SimpleMultiBuyDeal(5, 45, 'H'));
            deals.Add(new SimpleMultiBuyDeal(10, 80, 'H'));
            deals.Add(new SimpleMultiBuyDeal(2, 150, 'K'));
            deals.Add(new MultiBuyRemovalDeal(3, 'N', 1, 'M'));
            deals.Add(new SimpleMultiBuyDeal(5, 200, 'P'));
            deals.Add(new SimpleMultiBuyDeal(3, 80, 'Q'));
            deals.Add(new MultiBuyRemovalDeal(3, 'R', 1, 'Q'));
            deals.Add(new BuyXGetXFreeDeal('U', 3, 1));
            deals.Add(new SimpleMultiBuyDeal(2, 90, 'V'));
            deals.Add(new SimpleMultiBuyDeal(3, 130, 'V'));
            deals.Add(new AnyOfMultiBuyDeal(3, 45, 'S','T','X','Y','Z'));
        }

        public static List<Tuple<IMultiDeal, int>> FindDeals(char[] skus)
        {
            var foundDeals = new List<Tuple<IMultiDeal, int>>();

            foreach (var multiDeal in deals)
            {
                var possibleSavings = multiDeal.CalculatePossibleSavings(skus);

                if(possibleSavings > 0)
                    foundDeals.Add(new Tuple<IMultiDeal, int>(multiDeal, possibleSavings));
            }

            return foundDeals;
        }

        /// <summary>
        /// too expensive
        /// </summary>
        /// <param name="possibleDeals"></param>
        /// <returns></returns>
        public static List<List<int>> ComputeCombinations(List<Tuple<IMultiDeal, int>> possibleDeals)
        {
            if(possibleDeals.Count == 0)
                return new List<List<int>>();
            //if only one deal can be applied, just appliy it as many times as possible.
            if (possibleDeals.Count == 1)
                return new List<List<int>>
                {
                    Enumerable.Range(0, possibleDeals[0].Item2).Select(x => 0).ToList()
                };

            var baseCombination = new List<int>();

            baseCombination.AddRange(Enumerable.Range(0, possibleDeals.Count));

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

                    var possible = currentState.ToList();
                    resultSet.Add(possible);

                    state[j] += 1;
                    j = 0;
                }
                else
                {
                    state[j] = 0;
                    j++;
                }
            } while (j < baseCombination.Count);

            return resultSet.ToList();
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
                bool tryAgain = true;
                while (tryAgain)
                {
                    var res = availableDeals[dealIndex].Item1.Apply(caseProducts);
                    caseProducts = res.Item1;
                    total += res.Item2;
                    tryAgain = res.Item2 != 0;
                }
            }

            foreach (var product in caseProducts)
            {
                total += Catalog[product].Price;
            }

            return total;
        }

        public static int SimplePricing(char[] productsPurchased)
        {
            var total = 0;

            foreach (var product in productsPurchased)
            {
                total += Catalog[product].Price;
            }

            return total;
        }

        public static int ApplyHighValueDealsInOrder(List<Tuple<IMultiDeal, int>> dealsOrderedInValue, char[] productsPurchased)
        {
            var caseProducts = new char[productsPurchased.Length];
            productsPurchased.CopyTo(caseProducts, 0);
            var total = 0;

            foreach (var deal in dealsOrderedInValue)
            {
                bool tryAgain = true;
                while (tryAgain)
                {
                    var res = deal.Item1.Apply(caseProducts);
                    caseProducts = res.Item1;
                    total += res.Item2;
                    tryAgain = res.Item2 != 0;
                }
            }

            foreach (var product in caseProducts)
            {
                total += Catalog[product].Price;
            }

            return total;
        }
    }
}