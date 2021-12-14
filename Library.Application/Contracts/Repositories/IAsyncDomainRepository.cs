using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Contracts.Repositories
{
    public interface IAsyncDomainRepository<T> : IAsyncRepository<T> where T : class
    {
    }
}
