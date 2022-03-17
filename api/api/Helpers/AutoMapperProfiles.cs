using api.Dto;
using api.Models;
using AutoMapper;

namespace api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // CreateMap(Source, Destination)
            CreateMap<ReviewDto, Review>();
        }
    }
}
