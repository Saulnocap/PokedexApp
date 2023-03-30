using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Repos
{
    public class RegionRepos
    {
        private readonly PokedexContext _dbContext;

        public RegionRepos(PokedexContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Region region)
        {
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Region region)
        {
            _dbContext.Entry(region).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Region region)
        {
            _dbContext.Set<Region>().Remove(region);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbContext.Set<Region>().ToListAsync();
        }

        public async Task<Region> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Region>().FindAsync(id);
        }
    }
}
