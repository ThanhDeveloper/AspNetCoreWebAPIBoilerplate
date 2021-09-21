using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Context;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces;
using RepositoryPattern.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Repositories
{
    public class SongRepository : RepositoryBase<Song>, ISongRepository
    {
        private readonly IMapper _mapper;
        public SongRepository(DatabaseContext context, IMapper mapper) : base(context) {
            _mapper = mapper;
        }

        public async Task<IEnumerable<Song>> FindBooksByAuthor(string author) =>
            await db.m_song
                .Where(b => EF.Functions.Like(b.author, $"%{author}%"))
                .ToListAsync();

        public async Task<Song> GetByName(string name) =>
            await db.m_song
                .FirstOrDefaultAsync(b => b.name.Equals(name));

        public async Task CreateSong(SongRequest dto)
        {
            Song song = _mapper.Map<Song>(dto);
            await db.m_song.AddAsync(song);
            await db.SaveChangesAsync(); ;
        }
    }
}
