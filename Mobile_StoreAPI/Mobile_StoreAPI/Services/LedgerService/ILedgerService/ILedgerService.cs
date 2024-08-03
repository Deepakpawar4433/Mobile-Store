

using Mobile_StoreAPI.DTOs.RequestDto;
using Mobile_StoreAPI.DTOs.ResponseDto;

namespace Mobile_StoreAPI 
{
    public interface ILedgerService
    {
        Task<string> AddOrderData(OrderRequestDto orderRequestDto);
        public Task<List<OrderResponseDto>> GetAllOrders();
    }
}
