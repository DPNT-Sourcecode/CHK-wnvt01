namespace BeFaster.App.Solutions
{
    public class Product
    {
        public int Price { get; }
        public MultiBuy Deal { get; }

        public int PriceQuantity(int quantity)
        {
            if (Deal == null)
                return Price * quantity;

            var numberOfDeals = quantity / Deal.Quantity;
            var remainder = quantity % Deal.Quantity;

            return numberOfDeals * Deal.Price + remainder * Price;
        }

        public Product(int price, MultiBuy multiBuyDeal = null)
        {
            Price = price;
            Deal = multiBuyDeal;
        }
    }
}