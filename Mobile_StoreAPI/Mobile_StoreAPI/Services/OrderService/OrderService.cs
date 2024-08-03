using Mobile_StoreAPI.Models;
using Mobile_StoreAPI.Repository.IRepository;

namespace Mobile_StoreAPI.Services.OrderService
{
    public class OrderService : IOrderService.IOrderService
    {
        private readonly IRepository<Orders> _orderRepo;
        public OrderService(IRepository<Orders> orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public IEnumerable<Orders> getAllOrder()
        {
            return _orderRepo.GetAll();
        }
        public Orders GetOrderById(int id)
        {
            return _orderRepo.GetById(id);
        }
        public bool AddOrder(Orders order)
        {
            _orderRepo.Add(order);
            return true;
        }
        public bool UpdateOrder(Orders order)
        {
            _orderRepo.Update(order);
            return true;
        }
        public bool DeleteOrder(int Id)
        {
            try
            {
                var dataList = _orderRepo.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var data in dataList)
                {
                    _orderRepo.Delete(data);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
