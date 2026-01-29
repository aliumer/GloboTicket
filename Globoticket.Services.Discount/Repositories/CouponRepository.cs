using Globoticket.Services.Discount.DbContexts;
using Globoticket.Services.Discount.Entities;
using Microsoft.EntityFrameworkCore;

namespace Globoticket.Services.Discount.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly DiscountDbContext _discountDbContext;
        public CouponRepository(DiscountDbContext discountDbContext)
        {
            _discountDbContext = discountDbContext ?? throw new ArgumentNullException(nameof(discountDbContext));
        }

        public async Task<Coupon> GetCouponById(Guid couponId)
        {
            return await _discountDbContext.Coupons.Where(x => x.CouponId == couponId).FirstOrDefaultAsync();
        }

        public async Task<Coupon> GetCouponByUserId(Guid userId)
        {
            // TODO!
            return await _discountDbContext.Coupons.Where(x => x.UserId == userId).FirstOrDefaultAsync();
        }
    }
}
