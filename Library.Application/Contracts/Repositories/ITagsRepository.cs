using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Contracts.Repositories
{
    public interface ITagsRepository : IAsyncRepository<Tag>
    {
        Task<Tag> GetByName(string name);
    }
}
