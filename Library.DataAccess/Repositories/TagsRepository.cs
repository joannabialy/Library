using Library.Application.Contracts.Repositories;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public class TagsRepository : DomainBaseRepository<Tag>, ITagsRepository
    {
        public TagsRepository(LibraryDomainDbContext libraryDomainDbContext) : base(libraryDomainDbContext)
        {
        }

        public async Task<Tag> GetByName(string name)
        {
            return await _dbContext.Set<Tag>()
                .FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
