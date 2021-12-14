
using Library.Domain.Entities;
using System.Collections.Generic;

namespace Library.Application.Features.DigitalEntities.Queries.GetDigitalEntitiesList
{
    public class DigitalEntitiesListVM
    {
        public int DigitalEntityId { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public string Type { get; set; }
        public int CompanyId { get; set; }
        public int PersonId{ get; set; }
        public List<Tag> Tags { get; set; }
    }
}