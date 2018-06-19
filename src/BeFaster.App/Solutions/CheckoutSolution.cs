using System;
using System.Collections.Generic;
using System.Linq;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions
{
    public static class CheckoutSolution
    {
        private static Dictionary<char, Product> Catalog;

        static CheckoutSolution()
        {
            Catalog = new Dictionary<char, Product>();

            Catalog.Add('A', new Product(50, new MultiBuy(3, 130)));
            Catalog.Add('B', new Product(30, new MultiBuy(2, 45)));
            Catalog.Add('C', new Product(20));
            Catalog.Add('D', new Product(15));
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
                    total += Catalog[distinctProduct].PriceQuantity(numOfProduct);
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
