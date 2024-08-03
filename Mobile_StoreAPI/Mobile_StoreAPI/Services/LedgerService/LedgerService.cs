

using Mobile_StoreAPI.DTOs.RequestDto;
using Mobile_StoreAPI.DTOs.ResponseDto;
using Mobile_StoreAPI.Repository.IRepository;

namespace Mobile_StoreAPI
{
    public class LedgerService : ILedgerService
    {
        private readonly IRepository<Product> _productRepo;

        private readonly IRepository<Deals> _dealRepo;

        private readonly IRepository<Orders> _orderRepo;

        private readonly IRepository<OrderProductId> _orderProductIdRepo;

        public LedgerService(IRepository<Product> productRepo, IRepository<Deals> dealRepo, IRepository<Orders> orderRepo, IRepository<OrderProductId> orderProductIdRepo)
        {
            _productRepo = productRepo;
            _dealRepo = dealRepo;
            _orderRepo = orderRepo;
            _orderProductIdRepo = orderProductIdRepo;
        }

        public async Task<string> AddOrderData(OrderRequestDto orderRequestDto)
        {
            //get price of each product by respective ids
            var productList = _productRepo.Table.Where(s => orderRequestDto.ProductIds.Contains(s.Id)).ToList();

            //int? discountPercent = null;

            ////get deal by id
            //var deal = _dealRepo.Table.FirstOrDefault(d => d.Id == orderRequestDto.DealId);
            //if(deal != null)
            //{
            //    discountPercent = deal.Discount;
            //}

            int? discountPercent = _dealRepo.Table.FirstOrDefault(d => d.Id == orderRequestDto.DealId)?.Discount;

            //calculate discounted price and then add sum in transaction table
            int totalDiscountedOrderPrice = 0;
            int totalPrice = 0;
            foreach (var product in productList)
            {
                int discountedPrice = (int)product.ProductPricing * ((100 - (int)discountPercent) / 100);
                totalDiscountedOrderPrice = totalDiscountedOrderPrice + discountedPrice;
                totalPrice = totalPrice + (int)product.ProductPricing;
            }
            var order = new Orders()
            {
                DealId = orderRequestDto.DealId,
                SalerManId = orderRequestDto.SalesManId,
                OrderDate = DateOnly.FromDateTime(DateTime.Today),
                TotalSold = productList.Count,
                DiscountedAmount = totalDiscountedOrderPrice,
                Discount = discountPercent,
                TotalAmount = totalPrice,

            };

            //create one order and salesman id as well
            _orderRepo.Add(order);

            //add product in order to product mapping under that order id
            List<OrderProductId> orderProductIds = new List<OrderProductId>();
            foreach (var product in productList)
            {
                orderProductIds.Add(new OrderProductId()
                {
                    OrderId = order.Id,
                    ProductId = product.Id
                });
            }
            await _orderProductIdRepo.AddAll(orderProductIds);

            return "Order Created";
        }

        public async Task<List<OrderResponseDto>> GetAllOrders()
        {
            // Retrieve all orders
            var orders = _orderRepo.Table.ToList();

            var orderResponseList = new List<OrderResponseDto>();

            foreach (var order in orders)
            {
                // Retrieve product IDs for the order
                var orderProductIds = _orderProductIdRepo.Table.Where(op => op.OrderId == order.Id).Select(op => op.ProductId).ToList();

                // Retrieve product details for the product IDs
                var products = _productRepo.Table.Where(p => orderProductIds.Contains(p.Id)).ToList();

                // Prepare  for response DTO
                var orderResponse = new OrderResponseDto
                {
                    OrderId = order.Id,
                    DealsId = order.DealId,
                    SalerManId = order.SalerManId,
                    OrdersDate = order.OrderDate,
                    TotalSold = order.TotalSold,
                    DiscountedAmount = (int)order.DiscountedAmount,
                    Discount = order.Discount,
                    TotalAmount = order.TotalAmount,
                    Product = products.Select(p => new ProductDto
                    {
                        Id = p.Id,
                        ProductName = p.ProductName,
                        ProductPricing = p.ProductPricing,
                        Product_Type = p.Product_Type,
                        ProductDetails = p.ProductDetails,
                        ProductCreation = p.ProductCreation,
                        ProductModification = p.ProductModification,
                        BrandId = p.BrandId,

                    }).ToList()
                };

                orderResponseList.Add(orderResponse);
            }

            return orderResponseList;
        }
    }
}
