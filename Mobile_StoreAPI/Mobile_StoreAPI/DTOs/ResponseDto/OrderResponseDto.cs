namespace Mobile_StoreAPI.DTOs.ResponseDto
{
    public class OrderResponseDto
    {
        //public List<OrderDto> Orders { get; set; }

        public int OrderId { get; set; }
        public int? DealsId { get; set; }
        public int? SalerManId { get; set; }
        public DateOnly? OrdersDate { get; set; }
        public int? TotalSold { get; set; }
        public int? DiscountedAmount { get; set; }
        public int? Discount { get; set; }
        public int? TotalAmount { get; set; }
        public List<ProductDto> Product { get; set; }
    }
    public class OrderDto
    {
        public int? DealsId { get; set; }

        public string? OrderName { get; set; }

        public int? UsersId { get; set; }

        public int? BuyerId { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public DateOnly? CreatedOn { get; set; }

        public DateOnly? UpdatedOn { get; set; }

        public string SalerManName { get; set; }

        public DateOnly? OrdersDate { get; set; }

        public int? Discount { get; set; }

        public int? DiscountedAmount { get; set; }

        public int? TotalSold { get; set; }

        public List<Product> Product { get; set; }
    }
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? ProductPricing { get; set; }

        public string Product_Type { get; set; }

        public string ProductDetails { get; set; }

        public DateOnly? ProductCreation { get; set; }

        public DateOnly? ProductModification { get; set; }

        public int? BrandId { get; set; }


    }
}
