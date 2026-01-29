using AutoMapper;
using Globoticket.Services.Discount.Models;
using Globoticket.Services.Discount.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Globoticket.Services.Discount.Controllers
{
    [ApiController]
    [Route("api/discount")]
    public class DiscountController : Controller
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;

        public DiscountController(ICouponRepository couponRepository, IMapper mapper)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
        }

        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetDiscountForUser(Guid userId)
        {
            var coupon = await _couponRepository.GetCouponByUserId(userId);

            if (coupon == null)
                return NotFound();

            return Ok(_mapper.Map<CouponDto>(coupon));
        }

        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet("{couponId}")]
        public async Task<IActionResult> GetDiscountForCode(Guid couponId)
        {
            var coupon = await _couponRepository.GetCouponById(couponId);

            if (coupon == null)
                return NotFound();

            return Ok(_mapper.Map<CouponDto>(coupon));
        }
    }
}
