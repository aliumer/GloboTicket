using Globoticket.Services.Discount.Entities;

namespace Globoticket.Services.Discount.Repositories
{
    public interface ICouponRepository
    {
        Task<Coupon> GetCouponByUserId(Guid userId);
        Task<Coupon> GetCouponById(Guid couponId);
    }
}
