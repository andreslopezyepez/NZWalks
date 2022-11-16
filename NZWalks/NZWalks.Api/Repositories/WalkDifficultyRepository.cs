using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;
using NZWalks.Api.Repositories;

namespace NZWalks.Api.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalksDbContext _context;

        public WalkDifficultyRepository(NZWalksDbContext context)
        {
            _context = context;
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty record)
        {
            record.Id = Guid.NewGuid();
            await _context.AddAsync(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var record = await GetAsync(id);

            if (record is null) return null!;

            _context.Remove(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await _context.WalkDifficulties
                .ToListAsync();
        }

        public async Task<WalkDifficulty?> GetAsync(Guid id)
        {
            return await _context.WalkDifficulties
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty record)
        {
            var existingRecord = await GetAsync(id);
            if (existingRecord is null) return null!;

            existingRecord.Code = record.Code;            
            await _context.SaveChangesAsync();
            return existingRecord;
        }
    }
}
