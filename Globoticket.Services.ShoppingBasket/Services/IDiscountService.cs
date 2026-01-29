using Globoticket.Services.ShoppingBasket.Models;

namespace Globoticket.Services.ShoppingBasket.Services
{
    public interface IDiscountService
    {
        Task<Coupon> GetCoupon(Guid userId);
    }
}
