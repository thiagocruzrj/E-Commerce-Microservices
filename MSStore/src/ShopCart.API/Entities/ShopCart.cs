using System.Collections.Generic;

namespace ShopCart.API.Entities
{
    public class ShopCart
    {
        public string UserName { get; set; }
        public List<ShopCartItem> Item { get; set; } = new List<ShopCartItem>();

        public ShopCart() { }

        public ShopCart(string userName)
        {
            UserName = userName;
        }

        // Calculate total price shop cart
    }
}