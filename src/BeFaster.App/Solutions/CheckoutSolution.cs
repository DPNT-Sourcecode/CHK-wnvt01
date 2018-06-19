using System;
using System.Collections.Generic;
using System.Linq;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions
{
    public class MultiDeal
    {
        public Func<bool, IEnumerable<char>> FindDealFunc;

        public IEnumerable<MultiDeal> Conflicts;

        public Func<IEnumerable<char>, Tuple<IEnumerable<char>, int>> Apply;
    }

    public static class MultiDealEngine
    {
        List<MultiDeal> deals = new List<MultiDeal>();

        static MultiDealEngine()
        {
            
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
                var productsPurchased = skus.ToCharArray();

                var distinctProducts = productsPurchased.Distinct();

                var total = 0;


                foreach (var distinctProduct in distinctProducts)
                {
                    var numOfProduct = productsPurchased.Count(x => x == distinctProduct);



                }

                return total;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
