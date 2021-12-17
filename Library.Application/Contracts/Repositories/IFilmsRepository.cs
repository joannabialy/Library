using Library.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application.Contracts.Repositories
{
    public interface IFilmsRepository : IAsyncRepository<Film>
    {
        Task<Film> GetFilm(int id);
        Task<List<Film>> GetFilmsWithDirectorsAndCompanies();
        Task<List<Film>> GetFilmsWithTags();
        Task<List<Person>> GetDirectors();
        Task<List<Company>> GetCompanies();
    }
}
