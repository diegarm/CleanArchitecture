using Clean.Application.ViewModels;
using Clean.Domain.Entities;
using AutoMapper;

namespace Clean.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Person, PersonViewModel>();
        }

        
    }
}
