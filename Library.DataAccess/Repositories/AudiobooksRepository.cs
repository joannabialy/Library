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
    public class AudiobooksRepository : DomainBaseRepository<Audiobook>, IAudiobooksRepository
    {
        public AudiobooksRepository(LibraryDomainDbContext libraryDomainDbContext) : base(libraryDomainDbContext)
        {
        }

        public async Task<Audiobook> GetAudiobook(int id)
        {
            return await _dbContext.Set<Audiobook>()
                .Include(x => x.Author)
                .Include(x => x.Company)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.DigitalEntityId == id);
        }

        public async Task<List<Audiobook>> GetAudiobooksWithAuthorsAndCompanies()
        {
            var audiobooks = await _dbContext.Set<Audiobook>()
                .Include(x => x.Author)
                .Include(x => x.Company)
                .ToListAsync();

            return audiobooks;
        }

        public async Task<List<Audiobook>> GetAudiobooksWithTags()
        {
            var audiobooks = await _dbContext.Set<Audiobook>()
                .Include(x => x.Tags)
                .ToListAsync();

            return audiobooks;
        }

        public async Task<List<Person>> GetAuthors()
        {
            return await _dbContext.Set<Audiobook>()
                .Include(x => x.Author)
                .Select(x => x.Author)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<Company>> GetCompanies()
        {
            return await _dbContext.Set<Audiobook>()
                .Include(x => x.Company)
                .Select(x => x.Company)
                .Distinct()
                .ToListAsync();
        }
    }
}
