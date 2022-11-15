using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _context;

        public WalkRepository(NZWalksDbContext context)
        {
            _context = context;
        }

        public async Task<Walk> AddAsync(Walk record)
        {
            record.Id = Guid.NewGuid();
            await _context.AddAsync(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var record = await GetAsync(id);

            if (record is null) return null!;

            _context.Remove(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await _context.Walks
                .Include(x=> x.Region)
                .Include(x => x.WalkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk?> GetAsync(Guid id)
        {
            return await _context.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk record)
        {
            var existingRecord = await GetAsync(id);
            if (existingRecord is null) return null!;

            existingRecord.Name = record.Name;
            existingRecord.Length = record.Length;
            existingRecord.RegionId = record.RegionId;
            existingRecord.WalkDifficultyId = record.WalkDifficultyId;

            await _context.SaveChangesAsync();
            return existingRecord;
        }
    }
}
