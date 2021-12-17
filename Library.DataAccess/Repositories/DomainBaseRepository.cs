using Library.Application.Contracts.Repositories;

namespace Library.DataAccess.Repositories
{
    public class DomainBaseRepository<T> : BaseRepository<T>, IAsyncDomainRepository<T> where T : class
    {
        public DomainBaseRepository(LibraryDomainDbContext libraryDomainDbContext) : base(libraryDomainDbContext)
        {
        }
    }
}
