using Library.Application.Contracts.Repositories;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public class CompaniesRepository : DomainBaseRepository<Company>, ICompaniesRepository
    {
        public CompaniesRepository(LibraryDomainDbContext libraryDomainDbContext) : base(libraryDomainDbContext)
        {
        }

        public async Task<Company> GetByName(string name)
        {
            return await _dbContext.Set<Company>()
                .FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
