
using Library.Domain.Common;
using System;
using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DigitalEntity> Entities { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
