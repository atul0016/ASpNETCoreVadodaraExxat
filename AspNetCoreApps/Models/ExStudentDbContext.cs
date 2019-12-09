using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApps.Models
{
    public class ExStudentDbContext : DbContext
    {
        // define mapping
        public DbSet<University> Universities { get; set; }
        public DbSet<Student> Students { get; set; }


        /// <summary>
        /// The ctor will use DbContextOptions<T> parameter to map with the database
        /// using the connection string. This will be injected from AddDbContext<T>() method
        /// from ConfigureServices() method of Startup.cs
        /// </summary>
        /// <param name="options"></param>
        public ExStudentDbContext(DbContextOptions<ExStudentDbContext> options): base(options)
        {

        }
    }
}
