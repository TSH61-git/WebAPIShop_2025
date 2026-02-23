using AutoMapper;
using DTOs;
using Entities;
using NuGet.Protocol.Core.Types;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderReadDTO>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<OrderReadDTO>>(orders);
        }

        public async Task<OrderReadDTO> addOrder(OrderCreateDTO orderDto)
        {
            Order order = _mapper.Map<Order>(orderDto);
            order.OrderDate = DateOnly.FromDateTime(DateTime.Now);
            order.Status = "Accepted";
            Order newOrder = await _orderRepository.AddOrder(order);
            return _mapper.Map<OrderReadDTO>(newOrder);
        }
    }
}
