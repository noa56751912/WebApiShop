
using Entity;
using Repository;
using DTOs;
using AutoMapper;
namespace Services
{
    public class OrdersServices : IOrdersServices
    {
        public readonly IOrdersRepository _orders;
        public readonly IMapper _mapper;
        public OrdersServices(IOrdersRepository orders, IMapper mapper)
        {
            _orders = orders;
            _mapper = mapper;
        }

        public async Task<OrderDTO?> GetOrderById(int id)
        {
            var order = await _orders.GetOrderById(id);
            if (order == null)
            {
                return null;
            }
            return _mapper.Map<Order, OrderDTO>(order);
        }
        public async Task<OrderDTO> AddOrder(OrderDTO order)
        {
            return _mapper.Map<Order, OrderDTO>(await _orders.AddOrder(_mapper.Map<OrderDTO, Order>(order)));
        }
    }
}

