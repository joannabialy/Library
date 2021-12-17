using Library.Domain.Common;
using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DigitalEntity> DigitalEntities { get; set; }
    }
}
