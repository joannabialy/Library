using Library.Domain.Common;
using System;

namespace Library.Domain.Entities
{
    public class Magazine : DigitalEntity
    {
        public DateTime Issue { get; set; }
        public string ISBN { get; set; }
    }
}
