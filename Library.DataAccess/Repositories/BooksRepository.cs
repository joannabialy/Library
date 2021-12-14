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
    public class BooksRepository : DomainBaseRepository<Book>, IBooksRepository
    {
        public BooksRepository(LibraryDomainDbContext libraryDomainDbContext) : base(libraryDomainDbContext)
        {
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
    }
}
