using ApiFCamara.Application.Model;
using ApiFCamara.Domain.Model;
using AutoMapper;

namespace ApiFCamara.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, Product>();
        }
    }
}