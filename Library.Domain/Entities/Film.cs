using Library.Domain.Common;
using System;

namespace Library.Domain.Entities
{
    public class Film : DigitalEntity
    {
        public int DirectorId { get; set; }
        public Person Director { get; set; }
        public DateTime PremiereDate { get; set; }
    }
}
