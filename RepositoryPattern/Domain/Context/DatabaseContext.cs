using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.EntityConfiguration;
using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfiguration(new SongEntityTypeConfiguration());

        public DbSet<Song> m_song { get; set; }
    }
}
