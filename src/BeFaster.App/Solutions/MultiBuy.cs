namespace BeFaster.App.Solutions
{
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
}