using System;
using System.Collections.Generic;
using System.Linq;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions
{
    public class MultiDeal
    {
        public Func<char[], int> FindDealFunc;

        public Func<char[], Tuple<char[], int>> Apply;
    }

    public class SimpleMultiBuyDeal : MultiDeal
    {
        public SimpleMultiBuyDeal(int quantity, int price, char character)
        {
            FindDealFunc = x => x.Count(y => y == character) / quantity;
            Apply = x =>
            {
                if (x.Count(y => y == character) < quantity)
                    return new Tuple<char[], int>(x, 0);

                var remainingAs = x.Where(y => y == character).Skip(quantity).ToArray();
                var resultingObject = x.Where(y => y != character).Concat(remainingAs).OrderBy(y => y).ToArray();

                return new Tuple<char[], int>(resultingObject, price);
            };
        }
    }

    public static class MultiDealEngine
    {
        static List<MultiDeal> deals = new List<MultiDeal>();

        static MultiDealEngine()
        {
            deals.Add(new SimpleMultiBuyDeal(3, 130, 'A'));
        }
    }

    public static class CheckoutSolution
    {
        private static Dictionary<char, Product> Catalog;
        private static Dictionary<char, Func<string, IEnumerable<string>, int>> dealMapFunctions;

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