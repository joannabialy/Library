using Library.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application.Contracts.Repositories
{
    public interface IAudiobooksRepository : IAsyncRepository<Audiobook>
    {
        Task<List<Audiobook>> GetAudiobooksWithAuthorsAndCompanies();
        Task<List<Audiobook>> GetAudiobooksWithTags();
        Task<Audiobook> GetAudiobook(int id);
        Task<List<Person>> GetAuthors();
        Task<List<Company>> GetCompanies();
    }
}
