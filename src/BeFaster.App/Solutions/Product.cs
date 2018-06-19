namespace BeFaster.App.Solutions
{
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
}