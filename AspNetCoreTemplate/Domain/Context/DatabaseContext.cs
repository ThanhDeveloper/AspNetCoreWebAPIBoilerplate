using AspNetCoreTemplate.Domain.Entities;
using AspNetCoreTemplate.Domain.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTemplate.Domain.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SongEntityTypeConfiguration).Assembly);

        public DbSet<Song> Songs { get; set; }
    }
}
