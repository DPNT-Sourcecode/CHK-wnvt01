using System;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions
{
    public static class ProductPricing
    {
        
    }

    public class Product
    {
        public int Price { get; }
        public Func<int, int> MultiBuyFunc { get; }

        public Product(int price, Func<int, int> multiBuyFunc = null)
        {
            Price = price;

            if(multiBuyFunc == null)
                MultiBuyFunc = x => price*x;
            else
                MultiBuyFunc = multiBuyFunc;
        }
    }

    public static class CheckoutSolution
    {
        


        public static int Checkout(string skus)
        {
            var delimiters = new[] {","};

            var productsPurchased = skus.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        }
    }
}
