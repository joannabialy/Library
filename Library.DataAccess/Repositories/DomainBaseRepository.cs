using Library.Application.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public class DomainBaseRepository<T> : BaseRepository<T>, IAsyncDomainRepository<T> where T : class
    {
        public DomainBaseRepository(LibraryDomainDbContext libraryDomainDbContext) : base(libraryDomainDbContext)
        {
        }
    }
}
