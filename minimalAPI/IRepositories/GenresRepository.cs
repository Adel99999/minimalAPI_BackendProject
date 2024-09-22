using Microsoft.EntityFrameworkCore;
using minimalAPI.Data;
using minimalAPI.Models;

namespace minimalAPI.IRepositories
{
    public class GenresRepository : IGenresRepo
    {
        private readonly AppDbContext _db;
        public GenresRepository(AppDbContext db)
        {
            _db=db;
        }
        public async Task<int> Create(Genre obj)
        {
            _db.Genres.Add(obj);
            await _db.SaveChangesAsync();
            return obj.Id;

        }

        public async Task<List<Genre>> GetAll()
        {
            return await _db.Genres.ToListAsync();
        }

        public async Task<Genre> GetById(int id)
        {
            return await _db.Genres.FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task Delete(int id)
        {
            await _db.Genres.Where(g => g.Id == id).ExecuteDeleteAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _db.Genres.AnyAsync(g => g.Id == id);
        }
        public async Task Update(Genre genre)
        {
            _db.Update(genre);
            await _db.SaveChangesAsync();
        }
    }
}
