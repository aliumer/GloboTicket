using Globoticket.Services.ShoppingBasket.Entities;

namespace Globoticket.Services.ShoppingBasket.Services
{
    public interface IEventCatalogService
    {
        Task<Event> GetEvent(Guid id);
    }
}
