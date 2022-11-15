using AutoMapper;

namespace NZWalks.Api.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Models.Dto.Region>()
                .ForMember(d => d.Id, options => options.MapFrom(src => src.Id))
                .ReverseMap();            
        }
    }
}
