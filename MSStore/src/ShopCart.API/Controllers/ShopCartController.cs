using AutoMapper;
using EventBusRabbitMQ.Common;
using EventBusRabbitMQ.Events;
using EventBusRabbitMQ.Producer;
using Microsoft.AspNetCore.Mvc;
using ShopCart.API.Entities;
using ShopCart.API.Repositories.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ShopCart.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShopCartController : ControllerBase
    {
        private readonly IShopCartRepository _shopCartRepository;
        private readonly IMapper _mapper;
        private readonly EventBusRabbitMQProducer _eventBus;

        public ShopCartController(IShopCartRepository shopCartRepository, IMapper mapper, EventBusRabbitMQProducer eventBus)
        {
            _shopCartRepository = shopCartRepository ?? throw new ArgumentException(nameof(shopCartRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
            _eventBus = eventBus ?? throw new ArgumentException(nameof(eventBus));
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

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] ShopCartCheckout shopCartCheckout)
        {
            var shopCart = await _shopCartRepository.GetShopCart(shopCartCheckout.UserName); 
            if (shopCart == null) return BadRequest();

            var shopCartRemoved = await _shopCartRepository.DeleteShopCart(shopCart.UserName);
            if (!shopCartRemoved) return BadRequest();

            var eventMessage = _mapper.Map<ShopCartCheckoutEvent>(shopCartCheckout);
            eventMessage.RequestId = Guid.NewGuid();
            eventMessage.TotalPrice = shopCart.TotalPrice;

            try
            {
                _eventBus.PublishShopCartCheckout(EventBusConstants.SHOPCART_CHECKOUT_QUEUE, eventMessage);
            }
            catch (Exception)
            {
                throw;
            }

            return Accepted();
        }
    }
}