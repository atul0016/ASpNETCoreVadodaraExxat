using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreApps.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApps.Services
{
    public class StudentService : IService<Student, int>
    {
        private readonly ExStudentDbContext ctx;
        /// <summary>
        /// Injecting the DbContext class in the Service
        /// </summary>
        /// <param name="ctx"></param>
        public StudentService(ExStudentDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<Student> CreateAsync(Student entity)
        {
            var res = await ctx.Students.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var res = await ctx.Students.FindAsync(id);
            if (res == null) return false;

            ctx.Students.Remove(res);
            await ctx.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Student>> GetAsync()
        {
            var res = await ctx.Students.ToListAsync();
            return res;
        }

        public async Task<Student> GetAsync(int id)
        {
            var res = await ctx.Students.FindAsync(id);
            return res;
        }

        public async Task<Student> UpdateAsync(int id, Student entity)
        {
            var res = await ctx.Students.FindAsync(id);
            if (id != entity.StudentRowId) throw new Exception("Id does not match");
            if (res == null) throw new Exception("record not found");

            ctx.Entry<Student>(entity).State = EntityState.Modified;
            await ctx.SaveChangesAsync();
            return entity;
        }
    }
}
