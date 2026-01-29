using Globoticket.Services.EventCatalog.Entities;

namespace Globoticket.Services.EventCatalog.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(string categoryId);
    }
}
