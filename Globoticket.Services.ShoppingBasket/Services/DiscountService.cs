using Globoticket.Services.ShoppingBasket.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Globoticket.Services.ShoppingBasket.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient httpClient;
        public DiscountService(HttpClient client)
        {
            httpClient = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<Coupon> GetCoupon(Guid userId)
        {
            var response = await httpClient.GetAsync($"/api/discount/user/{userId}");
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var results = JsonConvert.DeserializeObject<Coupon>(responseString);
            return results;
        }
    }
}
