using AutoMapper;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos;
public class RestaurantsProfile : Profile
{
    public RestaurantsProfile()
    {
        CreateMap<Restaurant , RestaurantDto>()
            .ForMember(d => d.City , 
                opt => opt.MapFrom(x => x.Address == null ? null : x.Address.City))
            .ForMember(d => d.Street , opt => 
                opt.MapFrom(x => x.Address == null ? null :  x.Address.Street))
            .ForMember(d => d.PostalCode , opt => 
                opt.MapFrom(x => x.Address == null ? null :  x.Address.PostalCode))
            .ForMember(d => d.Dishes , opt => opt.MapFrom(x => x.Dishes));
    }
}
