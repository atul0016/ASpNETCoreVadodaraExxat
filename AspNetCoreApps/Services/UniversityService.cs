using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreApps.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApps.Services
{
    public class UniversityService : IService<University, int>
    {
        private readonly ExStudentDbContext ctx;
        /// <summary>
        /// Injecting the DbContext class in the Service
        /// </summary>
        /// <param name="ctx"></param>
        public UniversityService(ExStudentDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<University> CreateAsync(University entity)
        {
            var res = await ctx.Universities.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var res = await ctx.Universities.FindAsync(id);
            if (res == null) return false;

            ctx.Universities.Remove(res);
            await ctx.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<University>> GetAsync()
        {
            var res = await ctx.Universities.ToListAsync();
            return res;
        }

        public async Task<University> GetAsync(int id)
        {
            var res = await ctx.Universities.FindAsync(id);
            return res;
        }

        public async Task<University> UpdateAsync(int id, University entity)
        {
            var res = await ctx.Universities.FindAsync(id);
            if (id != entity.UniversityRowId) throw new Exception("Id does not match");
            if (res == null) throw new Exception("record not found");

            ctx.Entry<University>(entity).State = EntityState.Modified;
            await ctx.SaveChangesAsync();
            return entity;
        }
    }
}
