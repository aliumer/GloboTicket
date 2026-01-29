using AutoMapper;
using Globoticket.Services.EventCatalog.Entities;
using Globoticket.Services.EventCatalog.Models;

namespace Globoticket.Services.EventCatalog.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
