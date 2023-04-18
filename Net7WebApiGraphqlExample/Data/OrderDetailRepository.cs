using Microsoft.EntityFrameworkCore;
using Net7WebApiGraphqlExample.Entities;

namespace Net7WebApiGraphqlExample.Data
{
    public class OrderDetailRepository
    {
        private readonly StoreDbContext _storeDbContext;

        public OrderDetailRepository(StoreDbContext dbContext)
        {
            _storeDbContext = dbContext;
        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            return _storeDbContext.OrderDetails
                .Include(o => o.Order).ThenInclude(a => a.Account)
                .Include(p => p.Product)
                .ToList();
        }
    }
}
