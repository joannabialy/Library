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
    class MagazinesRepository : DomainBaseRepository<Magazine>, IMagazinesRepository
    {
        public MagazinesRepository(LibraryDomainDbContext libraryDomainDbContext) : base(libraryDomainDbContext)
        {
        }

        public async Task<Magazine> GetMagazine(int id)
        {
            return await _dbContext.Set<Magazine>()
                .Include(x => x.Company)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.DigitalEntityId == id);
        }

        public async Task<List<Magazine>> GetMagazinesWithCompanies()
        {
            var magazines = await _dbContext.Set<Magazine>()
                .Include(x => x.Company)
                .ToListAsync();

            return magazines;
        }

        public async Task<List<Magazine>> GetMagazinesWithTags()
        {
            var magazines = await _dbContext.Set<Magazine>()
                .Include(x => x.Tags)
                .ToListAsync();

            return magazines;
        }
    }
}
