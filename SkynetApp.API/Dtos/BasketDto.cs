namespace SkynetApp.API.Dtos
{
    public class BasketDto
    {
        public int Id { get; set; }
        public string BuyerId { get; set; } = string.Empty;
        public List<BasketItemDto> Items { get; set; }= new List<BasketItemDto>();
        public string PaymentIntentId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
    }
}
