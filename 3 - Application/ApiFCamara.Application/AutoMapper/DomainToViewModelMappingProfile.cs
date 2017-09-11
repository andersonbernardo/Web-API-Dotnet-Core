using ApiFCamara.Application.Model;
using ApiFCamara.Domain.Model;
using AutoMapper;

namespace ApiFCamara.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}