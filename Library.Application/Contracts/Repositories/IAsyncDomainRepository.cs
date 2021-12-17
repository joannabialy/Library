
namespace Library.Application.Contracts.Repositories
{
    public interface IAsyncDomainRepository<T> : IAsyncRepository<T> where T : class
    {
    }
}
