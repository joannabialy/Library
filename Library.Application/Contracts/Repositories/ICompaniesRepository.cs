using Library.Domain.Entities;
using System.Threading.Tasks;

namespace Library.Application.Contracts.Repositories
{
    public interface ICompaniesRepository : IAsyncRepository<Company>
    {
        Task<Company> GetByName(string name);
    }
}
