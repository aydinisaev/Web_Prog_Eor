using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ModelContext : DbContext
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Content> Contents { get; set; }
        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Model1db;Trusted_Connection=True;");
        }
    }
}
