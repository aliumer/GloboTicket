using AutoMapper;
using Globoticket.Services.ShoppingBasket.Models;
using Globoticket.Services.ShoppingBasket.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Globoticket.Services.ShoppingBasket.Controllers
{
    [ApiController]
    [Route("api/basketevent")]
    public class BasketChangeEventController : Controller
    {
        private readonly IBasketChangeEventRepository basketChangeEventRepository;
        private readonly IMapper mapper;
        public BasketChangeEventController(IBasketChangeEventRepository basketChangeEventRepository, IMapper mapper)
        {
            this.basketChangeEventRepository = basketChangeEventRepository ?? throw new ArgumentNullException(nameof(basketChangeEventRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents([FromQuery] DateTime fromDate, [FromQuery] int max)
        {
            var events = await basketChangeEventRepository.GetBasketChangeEvents(fromDate, max);
            return Ok(mapper.Map<List<BasketChangeEventForPublication>>(events));
        }

    }
}
