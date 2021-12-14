using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Contracts.Repositories
{
    public interface IFilmsRepository : IAsyncRepository<Film>
    {
        Task<Film> GetFilm(int id);
        Task<List<Film>> GetFilmsWithDirectorsAndCompanies();
        Task<List<Film>> GetFilmsWithTags();
    }
}
