using Library.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application.Contracts.Repositories
{
    public interface IMagazinesRepository : IAsyncRepository<Magazine>
    {
        Task<Magazine> GetMagazine(int id);
        Task<List<Magazine>> GetMagazinesWithCompanies();
        Task<List<Magazine>> GetMagazinesWithTags();
        Task<List<Company>> GetCompanies();
    }
}
