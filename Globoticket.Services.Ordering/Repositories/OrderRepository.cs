using Globoticket.Services.Ordering.DbContexts;
using Globoticket.Services.Ordering.Entities;
using Microsoft.EntityFrameworkCore;

namespace Globoticket.Services.Ordering.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<OrderDbContext> dbContextOptions;
        public OrderRepository(DbContextOptions<OrderDbContext> _dbContextOptions)
        {
            dbContextOptions = _dbContextOptions;
        }
        public async Task AddOrder(Order order)
        {
            await using (var _orderDbContext = new OrderDbContext(dbContextOptions))
            {
                await _orderDbContext.Orders.AddAsync(order);
                await _orderDbContext.SaveChangesAsync();
            }
        }

        public async Task<Order> GetOrderById(Guid orderId)
        {
            using (var _orderDbContext = new OrderDbContext(dbContextOptions))
            {
                return await _orderDbContext.Orders.Where(o => o.Id == orderId).FirstOrDefaultAsync();
            }
        }

        public async Task<List<Order>> GetOrdersForUser(Guid userId)
        {
            await using var _orderDbContext = new OrderDbContext(dbContextOptions);
            return await _orderDbContext.Orders.Where(o => o.UserId == userId).OrderBy(o => o.OrderPlaced).ToListAsync();
        }

        public async Task UpdateOrderPaymentStatus(Guid orderId, bool paid)
        {
            using (var _orderDbContext = new OrderDbContext(dbContextOptions))
            {
                var order = await _orderDbContext.Orders.Where(o => o.Id == orderId).FirstOrDefaultAsync();
                order.OrderPaid = paid;
                await _orderDbContext.SaveChangesAsync();
            }
        }
    }
}
