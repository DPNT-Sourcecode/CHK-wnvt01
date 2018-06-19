using System;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions
{
    public static class ProductPricing
    {
        
    }

    public class Product
    {
        public decimal Price { get; }
        public MultiBuy Deal { get; }

        public decimal MultiBuyFunc(int quantity)
        {
            if (Deal == null)
                return Price * quantity;

            var numberOfDeals = quantity / Deal.Quantity;
            var remainder = quantity % Deal.Quantity;

            return numberOfDeals * Deal.Price + remainder * Price;
        }

        public Product(decimal price, MultiBuy multiBuyDeal = null)
        {
            Price = price;
            Deal = multiBuyDeal;
        }
    }

    public class MultiBuy
    {
        public int Quantity { get; }
        public decimal Price { get; }

        public MultiBuy(int quantity, decimal price)
        {
            Quantity = quantity;
            Price = price;
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
