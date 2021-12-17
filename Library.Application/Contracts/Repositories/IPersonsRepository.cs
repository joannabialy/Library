using Library.Domain.Entities;
using System.Threading.Tasks;

namespace Library.Application.Contracts.Repositories
{
    public interface IPersonsRepository : IAsyncRepository<Person>
    {
        Task<Person> GetByName(string firstName, string lastName);
    }
}
