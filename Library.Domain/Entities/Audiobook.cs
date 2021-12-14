using System;

using Library.Domain.Common;

namespace Library.Domain.Entities
{
    public class Audiobook : DigitalEntity
    {
        public int AuthorId { get; set; }
        public Person Author { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
