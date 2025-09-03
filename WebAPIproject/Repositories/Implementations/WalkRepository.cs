using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebAPIproject.Data;
using WebAPIproject.Models.Domain;
using WebAPIproject.Repositories.Interfaces;

namespace WebAPIproject.Repositories.Implementations
{
    public class WalkRepository : IWalkRepository
    {
        private readonly ApplicationDbContext _context;

        public WalkRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
           await _context.Walks.AddAsync(walk);
           await _context.SaveChangesAsync();
           return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existWalkDTO = await _context.Walks.FirstOrDefaultAsync(p=> p.Id == id);
            if(existWalkDTO == null)
            {
                return null;
            }
            _context.Walks.Remove(existWalkDTO);
            await _context.SaveChangesAsync();
            return existWalkDTO;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 10)
        {
            var walks = _context.Walks.Include(p => p.Region).Include(p => p.Difficulty).AsQueryable();
            
            //----------------Filtering operation------------------------
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)// FilterOn and FilterQuery value are not Null/Empty/whiteSpace
            {
                //Walk.Name
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(p => p.Name.Contains(filterQuery));
                }

                //Walk.Region.Name -> filter by the related Region Name
                else if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(p => p.Region.Name.Contains(filterQuery));
                }
                //walk.Difficulty.Name
                else if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(p => p.Difficulty.Name.Contains(filterQuery));
                }
            }

            //----------------Sorting Operation-------------------------
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(p => p.Name) : walks.OrderByDescending(p => p.Name);
                }
                else if (sortBy.Equals("Length",StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(p => p.Length) : walks.OrderByDescending(p => p.Length);
                }
            }

            //----------------Pagination operation ----------------------
            var skipResults = (pageNumber - 1) * pageSize ;

            return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
            //return await _context.Walks.Include(p => p.Region).Include(p=>p.Difficulty). ToListAsync();    
        }
        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            var walkDomainModel = await _context.Walks.Include(p=>p.Difficulty).Include(p=>p.Region).FirstOrDefaultAsync(p => p.Id == id);
            
            return walkDomainModel;
        }

        public async Task<Walk?> UpdateAsync(Guid id,Walk walk)
        {
            var existingWalk = await _context.Walks.FirstOrDefaultAsync(p => p.Id == id);
            if(existingWalk == null)
            {
                return null; ;
            }

            // here update manually [in Repository best option manually update]
            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.Length = walk.Length;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await _context.SaveChangesAsync();
            return existingWalk;

        }
    }
}
