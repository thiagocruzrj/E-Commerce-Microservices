using AutoMapper;
using EventBusRabbitMQ.Events;
using ShopCart.API.Entities;

namespace ShopCart.API.Mapping
{
    public class ShopCartMapping : Profile
    {
        public ShopCartMapping()
        {
            CreateMap<ShopCartCheckout, ShopCartCheckoutEvent>().ReverseMap();
        }
    }
}