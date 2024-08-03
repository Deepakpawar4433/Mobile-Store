namespace Mobile_StoreAPI.DTOs.RequestDto
{
    public class OrderRequestDto
    {
        public List<int> ProductIds { get; set; }

        public int DealId { get; set; }

        public int SalesManId { get; set; }
    }
}
