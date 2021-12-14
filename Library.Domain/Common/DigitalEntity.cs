using System.Collections.Generic;

using Library.Domain.Entities;

namespace Library.Domain.Common
{
    public class DigitalEntity
    {
        public int DigitalEntityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public Company Company { get; set; }
        public List<Content> Content { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public int CompanyId { get; set; }
        public int Length { get; set; }
    }
}
