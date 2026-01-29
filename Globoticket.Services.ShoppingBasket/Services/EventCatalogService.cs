using Globoticket.Services.ShoppingBasket.Entities;
using Newtonsoft.Json;

namespace Globoticket.Services.ShoppingBasket.Services
{
    public class EventCatalogService : IEventCatalogService
    {
        private readonly HttpClient client;
        public EventCatalogService(HttpClient _client)
        {
            client = _client ?? throw new ArgumentNullException(nameof(_client));
        }

        public async Task<Event> GetEvent(Guid id)
        {
            var response = await client.GetAsync($"/api/events/{id}");
            var responseString = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var results = JsonConvert.DeserializeObject<Event>(responseString);
            return results;
        }
    }
}
