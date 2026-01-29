using AutoMapper;
using Globoticket.Services.Discount.Entities;
using Globoticket.Services.Discount.Models;

namespace Globoticket.Services.Discount.Profiles
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {
            CreateMap<Coupon, CouponDto>().ReverseMap();
        }
    }
}
