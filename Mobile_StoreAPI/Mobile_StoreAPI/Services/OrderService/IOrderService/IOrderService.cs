namespace Mobile_StoreAPI.Services.OrderService.IOrderService
{
    public interface IOrderService
    {
        public IEnumerable<Orders> getAllOrder();
        public Orders GetOrderById(int id);
        public bool AddOrder(Orders order);
        public bool DeleteOrder(int Id);
        public bool UpdateOrder(Orders order);
    }
}
