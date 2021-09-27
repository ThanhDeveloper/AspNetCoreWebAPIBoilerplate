using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Domain.EntityTypeConfigurations
{
    public class SongEntityTypeConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("d_songs");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Author)
                .HasColumnName("author")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.KindOfMusic)
                .HasColumnName("kind_of_music")
                .HasMaxLength(50);

            builder.Property(p => p.Rating)
                .HasColumnName("rating");

            builder.Property(p => p.View)
                .HasColumnName("view");

            builder.HasIndex(x => new { x.Id }).IsUnique();

            builder.HasData(
                new Song(1, "Remember When", "Alan Jackson", "Ballad", 4.6m, 120000),
                new Song(2, "Rolling in the deep ", "Adele", "Pop", 4.2m, 45000)
            );
        }
    }
}
