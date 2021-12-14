using System;

using Library.Domain.Common;

namespace Library.Domain.Entities
{
    public class Film : DigitalEntity
    {
        public int DirectorId { get; set; }
        public Person Director { get; set; }
        public DateTime PremiereDate { get; set; }
    }
}
