namespace ShopCart.API.Entities
{
    public class ShopCartItem
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
    }
}