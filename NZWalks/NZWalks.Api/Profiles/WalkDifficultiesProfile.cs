using AutoMapper;

namespace NZWalks.Api.Profiles
{
    public class WalkDifficultiesProfile : Profile
    {
        public WalkDifficultiesProfile()
        {
            CreateMap<Models.Domain.WalkDifficulty, Models.Dto.WalkDifficulty>()
                .ReverseMap();

            CreateMap<Models.Domain.WalkDifficulty, Models.Dto.AddWalkDifficultyRequest>()
                .ReverseMap();

            CreateMap<Models.Domain.WalkDifficulty, Models.Dto.UpdateWalkDifficultyRequest>()
                .ReverseMap();
        }
    }
}
