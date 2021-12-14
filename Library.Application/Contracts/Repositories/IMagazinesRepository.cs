using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Contracts.Repositories
{
    public interface IMagazinesRepository : IAsyncRepository<Magazine>
    {
        Task<Magazine> GetMagazine(int id);
        Task<List<Magazine>> GetMagazinesWithCompanies();
        Task<List<Magazine>> GetMagazinesWithTags();
    }
}
