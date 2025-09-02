using Microsoft.EntityFrameworkCore;
using WebAPIproject.Data;
using WebAPIproject.Models.Domain;
using WebAPIproject.Repositories.Interfaces;

namespace WebAPIproject.Repositories.Implementations
{
    public class RegionRepository : IRegionRepository
    {
        private readonly ApplicationDbContext _context;

        public RegionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await _context.Regions.AddAsync(region);
            await _context.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegion = await _context.Regions.FirstOrDefaultAsync(p => p.Id == id);
            if(existingRegion == null)
            {
                return null;
            }
            _context.Regions.Remove(existingRegion);
            await _context.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<List<Region>> GetAllAsync()
        {
           return await _context.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return  await _context.Regions.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existRegionModel = await _context.Regions.FirstOrDefaultAsync(p => p.Id == id);
            if (existRegionModel == null)
            {
                return null;
            }
            // here update manually [in Repository best option manually update]
            existRegionModel.Code = region.Code;
            existRegionModel.Name = region.Name;
            existRegionModel.RegionImageUrl = region.RegionImageUrl;
            await _context.SaveChangesAsync();

            return existRegionModel;

        }
    }
}
