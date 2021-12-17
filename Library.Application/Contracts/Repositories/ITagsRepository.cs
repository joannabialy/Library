using Library.Domain.Entities;
using System.Threading.Tasks;

namespace Library.Application.Contracts.Repositories
{
    public interface ITagsRepository : IAsyncRepository<Tag>
    {
        Task<Tag> GetByName(string name);
    }
}
