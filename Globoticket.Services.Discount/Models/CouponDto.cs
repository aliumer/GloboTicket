namespace Globoticket.Services.Discount.Models
{
    public class CouponDto
    {
        public Guid CouponId { get; set; }
        public Guid UserId { get; set; }
        public int Amount { get; set; }
    }
}
