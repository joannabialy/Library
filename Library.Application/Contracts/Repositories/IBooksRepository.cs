using Library.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application.Contracts.Repositories
{
    public interface IBooksRepository : IAsyncRepository<Book>
    {
        Task<Book> GetBook(int id);
        Task<List<Book>> GetBooksWithAuthorsAndCompanies();
        Task<List<Book>> GetBooksWithTags();
        Task<List<Person>> GetAuthors();
        Task<List<Company>> GetCompanies();
    }
}
