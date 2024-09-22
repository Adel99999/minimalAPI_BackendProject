using minimalAPI.Models;

namespace minimalAPI.IRepositories
{
    public interface IGenresRepo
    {
        Task<int> Create(Genre obj);
        Task<Genre> GetById(int id);
        Task<List<Genre>> GetAll();
        Task<bool> Exists(int id);
        Task Update(Genre genre);
        Task Delete(int id);
    }
}
