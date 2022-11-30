using SkynetApp.API.Entities.OrderAggregate;

namespace SkynetApp.API.Dtos
{
    public class CreateOrderDto
    {
        public bool SaveAddress { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
    }
}
