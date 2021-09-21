using RepositoryPattern.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryPattern.Data.EntityConfiguration
{
    public class SongEntityConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("m_song");

            builder.Property(p => p.id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.name)
                .HasColumnType("character varying(50)")
                .IsRequired();

            builder.Property(p => p.author)
                .HasColumnType("character varying(50)")
                .IsRequired();

            builder.Property(p => p.kind_of_music)
                .HasColumnType("character varying(50)");

            builder.Property(p => p.rating)
                .HasColumnType("numeric(18,2)");

            builder.Property(p => p.view)
                .HasColumnType("integer");

            builder.HasIndex(x => new { x.id }).IsUnique();

            builder.HasData(
                new Song(1, "Lạc trôi", "Sơn Tùng MTP", "Pop", 4.6m, 120000),
                new Song(2, "Sai cách yêu", "Lê Bảo Bình", "Nhạc Trẻ", 4.2m, 45000)
            );
        }
    }
}
