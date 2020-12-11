using AutoMapper;
using Entities;
using DTOs;

namespace Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TripElement, TripElementDto>();
            CreateMap<TripBag, TripBagDto>();
            CreateMap<Trip, TripDto>();
        }
    }
}