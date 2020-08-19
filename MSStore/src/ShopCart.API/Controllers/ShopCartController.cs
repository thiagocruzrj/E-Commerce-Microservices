using Microsoft.AspNetCore.Mvc;
using ShopCart.API.Entities;
using ShopCart.API.Repositories.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace ShopCart.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShopCartController : ControllerBase
    {
        private readonly IShopCartRepository _shopCartRepository;

        public ShopCartController(IShopCartRepository shopCartRepository)
        {
            _shopCartRepository = shopCartRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetShopCart(string userName)
        {
            var shopCart = await _shopCartRepository.GetShopCart(userName);
            return Ok(shopCart);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateShopCart([FromBody]ShoppingCart shoppingCart)
        {
            return Ok(await _shopCartRepository.UpdateShopCart(shoppingCart));
        }

        [HttpDelete("{userName}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveShopCart(string userName)
        {
            return Ok(await _shopCartRepository.DeleteShopCart(userName));
        }
    }
}