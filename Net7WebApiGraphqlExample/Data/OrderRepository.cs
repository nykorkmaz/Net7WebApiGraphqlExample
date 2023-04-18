using Microsoft.EntityFrameworkCore;
using Net7WebApiGraphqlExample.Entities;

namespace Net7WebApiGraphqlExample.Data
{
    public class OrderRepository
    {
        private readonly StoreDbContext _storeDbContext;

        public OrderRepository(StoreDbContext dbContext)
        {
            _storeDbContext = dbContext;
        }

        public List<Order> GetAllOrderwithDetails()
        {
            return _storeDbContext.Orders
                .Include(a => a.Account)
                .Include(o => o.orderDetails).ThenInclude(p => p.Product)
                .ToList();
        }
    }
}
