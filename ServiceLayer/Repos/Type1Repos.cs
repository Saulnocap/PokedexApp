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
    public class Type1Repos
    {
        private readonly PokedexContext _dbContext;

        public Type1Repos(PokedexContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region type1
        public async Task AddAsync(Type1 type)
        {
            await _dbContext.Type1s.AddAsync(type);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Type1 type)
        {
            _dbContext.Entry(type).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Type1 type)
        {
            _dbContext.Set<Type1>().Remove(type);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Type1>> GetAllAsync()
        {
            return await _dbContext.Set<Type1>().ToListAsync();
        }

        public async Task<Type1> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Type1>().FindAsync(id);
        }
        #endregion

    }
}
