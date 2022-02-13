using API_CRUD.Models.Concrete;
using API_CRUD.Models.DTOs;
using API_CRUD.Models.VMs;
using AutoMapper;

namespace API_CRUD.Infrastructure.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, GetCategoryVM>().ReverseMap();
            CreateMap<GetCategoryVM, Category>().ReverseMap();
            
            CreateMap<AppUser, AuthenticationDTO>().ReverseMap();
        }
    }
}
