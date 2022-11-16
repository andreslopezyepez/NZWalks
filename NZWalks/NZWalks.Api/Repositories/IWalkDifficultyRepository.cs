using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositories
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty>> GetAllAsync();
        Task<WalkDifficulty?> GetAsync(Guid id);
        Task<WalkDifficulty> AddAsync(WalkDifficulty record);
        Task<WalkDifficulty> DeleteAsync(Guid id);
        Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty record);
    }
}
