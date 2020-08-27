using System.Collections.Generic;

namespace AspnetRunBasics.Models
{
    public class ShopCartModel
    {
        public string UserName { get; set; }
        public List<ShopCartItemModel> Items { get; set; } = new List<ShopCartItemModel>();
        public decimal TotalPrice { get; set; }
    }
}