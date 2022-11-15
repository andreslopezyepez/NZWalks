using AutoMapper;

namespace NZWalks.Api.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile()
        {
            CreateMap<Models.Domain.Walk, Models.Dto.Walk>()
                .ReverseMap();

            CreateMap<Models.Domain.Walk, Models.Dto.AddWalkRequest>()
                .ReverseMap();

            CreateMap<Models.Domain.Walk, Models.Dto.UpdateWalkRequest>()
                .ReverseMap();

            //Navigation
            CreateMap<Models.Domain.WalkDifficulty, Models.Dto.WalkDifficulty>()
                .ReverseMap();
        }
    }
}
