using Library.Application.Contracts.Repositories;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public class BooksRepository : DomainBaseRepository<Book>, IBooksRepository
    {
        public BooksRepository(LibraryDomainDbContext libraryDomainDbContext) : base(libraryDomainDbContext)
        {
        }

        public async Task<List<Person>> GetAuthors()
        {
            return (await _dbContext.Set<Book>()
                .Include(x => x.Author)
                .Select(x => x.Author)
                .Distinct()
                .ToListAsync());
        }

        public async Task<Book> GetBook(int id)
        {
            return await _dbContext.Set<Book>()
                .Include(x => x.Author)
                .Include(x => x.Company)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.DigitalEntityId == id);
        }

        public async Task<List<Book>> GetBooksWithAuthorsAndCompanies()
        {
            var books = await _dbContext.Set<Book>()
                .Include(x => x.Author)
                .Include(x => x.Company)
                .ToListAsync();

            return books;
        }

        public async Task<List<Book>> GetBooksWithTags()
        {
            var books = await _dbContext.Set<Book>()
                .Include(x => x.Tags)
                .ToListAsync();

            return books;
        }

        public async Task<List<Company>> GetCompanies()
        {
            return (await _dbContext.Set<Book>()
                .Include(x => x.Company)
                .Select(x => x.Company)
                .Distinct()
                .ToListAsync());
        }
    }
}
