using Application.Models;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<NewProperty, Property>();
            CreateMap<UpdateProperty, Property>();
            CreateMap<Property, PropertyDto>();
            CreateMap<Property, List<PropertyDto>>();

            CreateMap<NewImage, Image>();
            CreateMap<UpdateImage, Image>();
            CreateMap<Image, ImageDto>();
            CreateMap<Image, List<ImageDto>>();


        }
    }
}
