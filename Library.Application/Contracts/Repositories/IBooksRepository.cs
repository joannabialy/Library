using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Contracts.Repositories
{
    public interface IBooksRepository : IAsyncRepository<Book>
    {
        Task<Book> GetBook(int id);
        Task<List<Book>> GetBooksWithAuthorsAndCompanies();
        Task<List<Book>> GetBooksWithTags();
    }
}
