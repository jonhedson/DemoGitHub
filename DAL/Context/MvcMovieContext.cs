using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace DAL.Context
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MvcMovieContext>
    {
        public MvcMovieContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../MvcMovie/appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<MvcMovieContext>();
            var connectionString = configuration.GetConnectionString("MvcMovieConnStr");
            builder.UseSqlServer(connectionString);
            return new MvcMovieContext(builder.Options);
        }
    }
}

