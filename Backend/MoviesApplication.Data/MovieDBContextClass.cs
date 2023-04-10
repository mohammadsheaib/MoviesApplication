using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoviesApplication.Entities;

namespace MoviesApplication.Data
{
    public class MovieDBContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;

        public MovieDBContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Movie> Movies { get; set; }
    }
}