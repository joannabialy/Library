using Library.Application.Contracts.Repositories;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public class PersonsRepository : DomainBaseRepository<Person>, IPersonsRepository
    {
        public PersonsRepository(LibraryDomainDbContext libraryDomainDbContext) : base(libraryDomainDbContext)
        {
        }

        public async Task<Person> GetByName(string firstName, string lastName)
        {
            return await _dbContext.Set<Person>()
                .FirstOrDefaultAsync(x => x.FirstName == firstName && x.LastName == x.LastName);
        }
    }
}
