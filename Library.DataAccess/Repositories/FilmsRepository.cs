using Library.Application.Contracts.Repositories;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public class FilmsRepository : DomainBaseRepository<Film>, IFilmsRepository
    {
        public FilmsRepository(LibraryDomainDbContext libraryDomainDbContext) : base(libraryDomainDbContext)
        {
        }

        public async Task<Film> GetFilm(int id)
        {
            return await _dbContext.Set<Film>()
                .Include(x => x.Director)
                .Include(x => x.Company)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.DigitalEntityId == id);
        }

        public async Task<List<Film>> GetFilmsWithDirectorsAndCompanies()
        {
            var films = await _dbContext.Set<Film>()
                .Include(x => x.Director)
                .Include(x => x.Company)
                .ToListAsync();

            return films;
        }

        public async Task<List<Film>> GetFilmsWithTags()
        {
            var films = await _dbContext.Set<Film>()
                .Include(x => x.Tags)
                .ToListAsync();

            return films;
        }
    }
}
