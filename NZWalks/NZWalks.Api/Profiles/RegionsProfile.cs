using AutoMapper;

namespace NZWalks.Api.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Models.Dto.Region>()                
                .ReverseMap();

            CreateMap<Models.Domain.Region, Models.Dto.AddRegionRequest>()
                .ReverseMap();

            CreateMap<Models.Domain.Region, Models.Dto.UpdateRegionRequest>()
                .ReverseMap();
        }
    }
}
